using System.Collections.Generic;
using BandCamp.Infrastructure.Repositories;
using BandCamp.Models;
using BandCamp.Patterns.Creational;

namespace BandCamp.Services
{
    public class TourService
    {
        private readonly ITourRepository _tourRepo;

        public TourService(ITourRepository tourRepo)
        {
            _tourRepo = tourRepo;
        }

        public List<Tour> GetAllTours() => _tourRepo.GetAll();

        public List<Tour> GetToursByBandId(int bandId) =>
            _tourRepo.GetToursByBandId(bandId);

        public Tour GetById(int id) => _tourRepo.GetById(id);

        public void CreateTour(
            string name, int bandId, string bandName,
            System.DateTime startDate, System.DateTime endDate,
            decimal budget, string country)
        {
            // Используем Builder
            var tour = new TourBuilder()
                .SetName(name)
                .SetBand(bandId)
                .SetDates(startDate, endDate)
                .SetBudget(budget)
                .SetCountry(country)
                .Build();

            tour.BandName = bandName;
            _tourRepo.Add(tour);
        }

        public void DeleteTour(int id) => _tourRepo.Delete(id);
    }
}