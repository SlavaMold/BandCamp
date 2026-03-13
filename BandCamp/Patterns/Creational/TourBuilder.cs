using System;
using BandCamp.Models;

namespace BandCamp.Patterns.Creational
{
    public class TourBuilder
    {
        private readonly Tour _tour = new Tour();

        public TourBuilder SetName(string name)
        {
            _tour.Name = name;
            return this;
        }

        public TourBuilder SetBand(int bandId)
        {
            _tour.BandId = bandId;
            return this;
        }

        public TourBuilder SetDates(DateTime start, DateTime end)
        {
            _tour.StartDate = start;
            _tour.EndDate = end;
            return this;
        }

        public TourBuilder SetBudget(decimal budget)
        {
            _tour.Budget = budget;
            return this;
        }

        public TourBuilder SetCountry(string country)
        {
            _tour.Country = country;
            return this;
        }

        public TourBuilder AddConcert(Concert concert)
        {
            _tour.Concerts.Add(concert);
            return this;
        }

        public Tour Build()
        {
            if (string.IsNullOrWhiteSpace(_tour.Name))
                throw new InvalidOperationException("Название тура обязательно");
            if (_tour.BandId == 0)
                throw new InvalidOperationException("Группа не выбрана");
            if (_tour.StartDate >= _tour.EndDate)
                throw new InvalidOperationException("Дата начала должна быть раньше даты окончания");
            return _tour;
        }
    }
}