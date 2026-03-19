using System.Collections.Generic;
using BandCamp.Infrastructure.Repositories;
using BandCamp.Models;
using BandCamp.Patterns.Behavioral;
using BandCamp.Patterns.Creational;
using BandCamp.Services;

namespace BandCamp.Patterns.Structural
{
    public class BandManagerFacade
    {
        private readonly BandService _bandService;
        private readonly MemberService _memberService;
        private readonly TourService _tourService;

        public BandManagerFacade()
        {
            _bandService = new BandService(new BandRepository());
            _memberService = new MemberService(new MemberRepository());
            _tourService = new TourService(new TourRepository());
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

        // --- Tour operations ---

        public string SaveTour(TourBuilder builder)
        {
            try
            {
                var tour = builder.Build();
                _tourService.AddTour(tour);
                return null;
            }
            catch (System.Exception ex)
            {
                return ex.Message;
            }
        }

        public List<Tour> GetToursOfBand(int bandId) =>
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

    }
}