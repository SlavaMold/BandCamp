using System.Collections.Generic;
using BandCamp.Infrastructure.Repositories;
using BandCamp.Models;

namespace BandCamp.Services
{
    public class BandService
    {
        private readonly IBandRepository _bandRepo;

        public BandService(IBandRepository bandRepo)
        {
            _bandRepo = bandRepo;
        }

        public List<Band> GetAllBands() => _bandRepo.GetAll();

        public Band GetBandById(int id) => _bandRepo.GetById(id);

        public void AddBand(Band band) => _bandRepo.Add(band);

        public void UpdateBand(Band band) => _bandRepo.Update(band);

        public void DeleteBand(int id) => _bandRepo.Delete(id);

        public List<Member> GetMembersOfBand(int bandId) =>
            _bandRepo.GetMembersByBandId(bandId);
    }
}