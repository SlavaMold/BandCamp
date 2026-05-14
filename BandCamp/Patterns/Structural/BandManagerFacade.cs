using BandCamp.Infrastructure.Repositories;
using BandCamp.Models;
using BandCamp.Patterns.Behavioral;
using BandCamp.Patterns.Creational;
using BandCamp.Services;
using System;
using System.Collections.Generic;

namespace BandCamp.Patterns.Structural
{
    public class BandManagerFacade
    {
        private readonly ConcertService _concertService;
        private readonly BandService _bandService;
        private readonly MemberService _memberService;
        private readonly TourService _tourService;
        private readonly ContractService _contractService;

        public BandManagerFacade()
        {
            _bandService = new BandService(new BandRepository());
            _memberService = new MemberService(new MemberRepository());
            _tourService = new TourService(new TourRepository());
            _contractService = new ContractService(new ContractRepository());
            _concertService = new ConcertService(
            new ConcertRepository(),
            new ContractRepository());
        }

        // --- Band operations ---

        public string SaveBand(Band band)
        {
            var validator = new BandNameValidator();
            validator.SetNext(new BandGenreValidator());
            string error = validator.Handle(band);
            if (error != null) return error;

            if (band.Id == 0) _bandService.AddBand(band);
            else _bandService.UpdateBand(band);
            return null;
        }

        public List<Band> GetAllBands() => _bandService.GetAllBands();
        public Band GetBand(int id) => _bandService.GetBandById(id);
        public void DeleteBand(int id) => _bandService.DeleteBand(id);

        // --- Member operations ---

        public string SaveMember(Member member, int bandId)
        {
            var validator = new MemberNameValidator();
            validator.SetNext(new MemberRoleValidator());
            string error = validator.Handle(member);
            if (error != null) return error;

            if (member.Id == 0)
            {
                _memberService.AddMember(member);
                if (bandId > 0)
                    _memberService.AddMemberToBand(member.Id, bandId);
            }
            else
            {
                _memberService.UpdateMember(member);
            }
            return null;
        }

        public List<Member> GetMembersOfBand(int bandId) =>
            _bandService.GetMembersOfBand(bandId);

        public void RemoveMemberFromBand(int memberId, int bandId) =>
            _memberService.RemoveMemberFromBand(memberId, bandId);

        public List<Member> GetAllMembers() => _memberService.GetAllMembers();

        public Member GetMember(int id) => _memberService.GetMemberById(id);

        public void DeleteMember(int id) => _memberService.DeleteMember(id);

        // --- Tour operations ---

        public string CreateTour(
    string name, int bandId, string bandName,
    DateTime startDate, DateTime endDate,
    decimal budget, string country)
        {
            try
            {
                _tourService.CreateTour(
                    name, bandId, bandName,
                    startDate, endDate,
                    budget, country);
                return null;
            }
            catch (System.Exception ex)
            {
                return ex.Message;
            }
        }

        public List<Tour> GetToursOfBand(int bandId) =>
            _tourService.GetToursByBandId(bandId);

        public List<Tour> GetAllTours() => _tourService.GetAllTours();

        public List<Tour> GetToursByBand(int bandId) =>
            _tourService.GetToursByBandId(bandId);

        public void DeleteTour(int id) => _tourService.DeleteTour(id);

        public System.Drawing.Image GetMemberPhoto(string photoPath)
        {
            IMemberImage proxy = new MemberImageProxy(photoPath);
            return proxy.GetPhoto();
        }

        // --- Composite ---
        public BandCatalog BuildCatalog(Band band)
        {
            var catalog = new BandCatalog(band.Name);
            var album = new MusicAlbum($"Альбом группы {band.Name}");
            album.Add(new MusicTrack("Трек 1", 210));
            album.Add(new MusicTrack("Трек 2", 185));
            catalog.Add(album);
            return catalog;
        }

        // --- Bridge: preview ---
        public string ExportMembersPreview(int bandId)
        {
            var members = GetMembersOfBand(bandId);
            var renderer = new TextPreviewRenderer();
            var exporter = new MembersExporter(members, renderer);
            exporter.Export();
            return renderer.Result;
        }

        // --- Bridge: CSV ---
        public void ExportMembersCsv(int bandId, string filePath)
        {
            var members = GetMembersOfBand(bandId);
            var renderer = new CsvExportRenderer(filePath);
            var exporter = new MembersExporter(members, renderer);
            exporter.Export();
        }

        public void ExportToursCsv(int bandId, string filePath)
        {
            var tours = GetToursOfBand(bandId);
            var renderer = new CsvExportRenderer(filePath);
            var exporter = new ToursExporter(tours, renderer);
            exporter.Export();
        }

    public void CreateRecordingContract(
    string studioName, string responsiblePerson,
    DateTime startDate, DateTime endDate,
    decimal payment, int bandId, string bandName, string productName)
        {
            _contractService.CreateContract(
                ContractType.Recording,
                studioName, responsiblePerson,
                startDate, endDate,
                payment, bandId, bandName, productName);
        }

        public List<Contract> GetAllContracts() =>
            _contractService.GetAllContracts();

        public List<Contract> GetRecordingContracts() =>
            _contractService.GetByType(ContractType.Recording);

        public void DeleteContract(int id) =>
            _contractService.DeleteContract(id);


    public void CreateConcert(
    string name, int bandId, string bandName,
    DateTime date, string responsiblePerson,
    decimal payment, string comment)
        {
            _concertService.CreateConcertWithContract(
            name, bandId, bandName,
            date, responsiblePerson,
            payment, comment);
        }

        public List<Concert> GetAllConcerts() =>
            _concertService.GetAllConcerts();

        public void DeleteConcert(int id) =>
            _concertService.DeleteConcert(id);

        public string GenerateTextReport(string reportType)
        {
            IReportFactory factory = new TextReportFactory();
            IReport report = BuildReport(factory, reportType);
            return report?.Generate() ?? "Неизвестный тип отчёта";
        }

        public string GenerateCsvReport(string reportType, string outputFolder)
        {
            IReportFactory factory = new CsvReportFactory(outputFolder);
            IReport report = BuildReport(factory, reportType);
            return report?.Generate() ?? "Неизвестный тип отчёта";
        }

        private IReport BuildReport(IReportFactory factory, string reportType)
        {
            switch (reportType)
            {
                case "members":
                    return factory.CreateMembersReport(_memberService.GetAllMembers());
                case "concerts":
                    return factory.CreateConcertsReport(_concertService.GetAllConcerts());
                case "contracts":
                    return factory.CreateContractsReport(_contractService.GetAllContracts());
                default:
                    return null;
            }
        }

    }

}