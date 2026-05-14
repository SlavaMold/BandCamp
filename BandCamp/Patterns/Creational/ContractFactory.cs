using System;
using BandCamp.Models;

namespace BandCamp.Patterns.Creational
{
    // Product — базовый контракт
    public abstract class ContractCreator
    {
        public abstract ContractType GetContractType();

        // Factory Method
        public Contract CreateContract(
            string studioName,
            string responsiblePerson,
            DateTime startDate,
            DateTime endDate,
            decimal payment,
            int bandId,
            string bandName,
            string productName)
        {
            var contract = new Contract
            {
                Type = GetContractType(),
                StudioName = studioName,
                ResponsiblePerson = responsiblePerson,
                StartDate = startDate,
                EndDate = endDate,
                Payment = payment,
                BandId = bandId,
                BandName = bandName,
                ProductName = productName
            };

            OnContractCreated(contract);
            return contract;
        }

        // Хук — подклассы могут добавить логику после создания
        protected virtual void OnContractCreated(Contract contract) { }
    }

    // Concrete Creator 1 — контракт на запись
    public class RecordingContractCreator : ContractCreator
    {
        public override ContractType GetContractType() => ContractType.Recording;

        protected override void OnContractCreated(Contract contract)
        {
            // Для записи продукт — это название альбома
            if (string.IsNullOrWhiteSpace(contract.ProductName))
                contract.ProductName = "Новый альбом";
        }
    }

    // Concrete Creator 2 — контракт на концерт
    public class ConcertContractCreator : ContractCreator
    {
        public override ContractType GetContractType() => ContractType.Concert;

        protected override void OnContractCreated(Contract contract)
        {
            // Для концерта начало и конец — один день
            contract.EndDate = contract.StartDate;
        }
    }

    // Concrete Creator 3 — контракт на тур (для этапа 2)
    public class TourContractCreator : ContractCreator
    {
        public override ContractType GetContractType() => ContractType.Tour;
    }

    // Фабрика-роутер — выдаёт нужный Creator по типу
    public static class ContractCreatorFactory
    {
        public static ContractCreator GetCreator(ContractType type)
        {
            switch (type)
            {
                case ContractType.Recording: return new RecordingContractCreator();
                case ContractType.Concert: return new ConcertContractCreator();
                case ContractType.Tour: return new TourContractCreator();
                default: throw new ArgumentException($"Неизвестный тип контракта: {type}");
            }
        }
    }
}