using System;
using System.Collections.Generic;
using BandCamp.Infrastructure.Repositories;
using BandCamp.Models;
using BandCamp.Patterns.Creational;

namespace BandCamp.Services
{
    public class ConcertService
    {
        private readonly IConcertRepository _concertRepo;
        private readonly IContractRepository _contractRepo;

        public ConcertService(
            IConcertRepository concertRepo,
            IContractRepository contractRepo)
        {
            _concertRepo = concertRepo;
            _contractRepo = contractRepo;
        }

        public List<Concert> GetAllConcerts() => _concertRepo.GetAll();

        public Concert GetById(int id) => _concertRepo.GetById(id);

        // Factory Method создаёт контракт и концерт вместе
        public void CreateConcertWithContract(
            string name,
            int bandId,
            string bandName,
            DateTime date,
            string responsiblePerson,
            decimal payment,
            string comment)
        {
            // Используем Factory Method — ConcertContractCreator
            var creator = ContractCreatorFactory.GetCreator(ContractType.Concert);
            var contract = creator.CreateContract(
                studioName: "",
                responsiblePerson: responsiblePerson,
                startDate: date,
                endDate: date,
                payment: payment,
                bandId: bandId,
                bandName: bandName,
                productName: name);

            _contractRepo.Add(contract);

            var concert = new Concert
            {
                Name = name,
                BandId = bandId,
                BandName = bandName,
                Date = date,
                ResponsiblePerson = responsiblePerson,
                Payment = payment,
                Comment = comment,
                ContractId = contract.Id
            };

            _concertRepo.Add(concert);
        }

        public void DeleteConcert(int id) => _concertRepo.Delete(id);
    }
}