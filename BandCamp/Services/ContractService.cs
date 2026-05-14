using System.Collections.Generic;
using BandCamp.Infrastructure.Repositories;
using BandCamp.Models;
using BandCamp.Patterns.Creational;

namespace BandCamp.Services
{
    public class ContractService
    {
        private readonly IContractRepository _repo;

        public ContractService(IContractRepository repo)
        {
            _repo = repo;
        }

        public List<Contract> GetAllContracts() => _repo.GetAll();

        public List<Contract> GetByType(ContractType type) =>
            _repo.GetContractsByType(type);

        public void CreateContract(
            ContractType type,
            string studioName,
            string responsiblePerson,
            System.DateTime startDate,
            System.DateTime endDate,
            decimal payment,
            int bandId,
            string bandName,
            string productName)
        {
            // Используем Factory Method
            var creator = ContractCreatorFactory.GetCreator(type);
            var contract = creator.CreateContract(
                studioName, responsiblePerson,
                startDate, endDate,
                payment, bandId, bandName, productName);

            _repo.Add(contract);
        }

        public void DeleteContract(int id) => _repo.Delete(id);

        public Contract GetById(int id) => _repo.GetById(id);
    }
}