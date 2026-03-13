using System.Collections.Generic;
using BandCamp.Infrastructure.Repositories;
using BandCamp.Models;

namespace BandCamp.Services
{
    public class TourService
    {
        private readonly ITourRepository _tourRepo;

        public TourService(ITourRepository tourRepo)
        {
            _tourRepo = tourRepo;
        }

        public List<Tour> GetToursByBandId(int bandId) =>
            _tourRepo.GetToursByBandId(bandId);

        public void AddTour(Tour tour) => _tourRepo.Add(tour);

        public void UpdateTour(Tour tour) => _tourRepo.Update(tour);

        public void DeleteTour(int id) => _tourRepo.Delete(id);
    }
}