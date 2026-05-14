using BandCamp.Models;
using BandCamp.Patterns.Structural;

namespace BandCamp.Patterns.Behavioral
{
    public class DeleteBandCommand : ICommand
    {
        private readonly BandManagerFacade _facade;
        private Band _band;

        public string Description => $"Удаление группы «{_band.Name}»";

        public DeleteBandCommand(BandManagerFacade facade, Band band)
        {
            _facade = facade;
            _band = band;
        }

        public void Execute() => _facade.DeleteBand(_band.Id);

        public void Undo()
        {
            var restored = new Band
            {
                Name = _band.Name,
                Genre = _band.Genre,
                FormationDate = _band.FormationDate,
                Description = _band.Description
            };
            _facade.SaveBand(restored);
            // Запоминаем новый ID чтобы Redo мог удалить правильную запись
            _band = restored;
        }

        public ICommand CreateFresh() =>
            new DeleteBandCommand(_facade, _band);
    }

    public class DeleteMemberCommand : ICommand
    {
        private readonly BandManagerFacade _facade;
        private Member _member;

        public string Description => $"Удаление участника «{_member.FullName}»";

        public DeleteMemberCommand(BandManagerFacade facade, Member member)
        {
            _facade = facade;
            _member = member;
        }

        public void Execute() => _facade.DeleteMember(_member.Id);

        public void Undo()
        {
            var restored = new Member
            {
                FirstName = _member.FirstName,
                LastName = _member.LastName,
                Role = _member.Role,
                ExperienceYears = _member.ExperienceYears,
                JoinDate = _member.JoinDate,
                PhotoPath = _member.PhotoPath,
                IsActive = _member.IsActive
            };
            _facade.SaveMember(restored, 0);
            _member = restored;
        }

        public ICommand CreateFresh() =>
            new DeleteMemberCommand(_facade, _member);
    }

    public class DeleteConcertCommand : ICommand
    {
        private readonly BandManagerFacade _facade;
        private Concert _concert;

        public string Description => $"Удаление концерта «{_concert.Name}»";

        public DeleteConcertCommand(BandManagerFacade facade, Concert concert)
        {
            _facade = facade;
            _concert = concert;
        }

        public void Execute() => _facade.DeleteConcert(_concert.Id);

        public void Undo()
        {
            _facade.CreateConcert(
                _concert.Name,
                _concert.BandId,
                _concert.BandName,
                _concert.Date,
                _concert.ResponsiblePerson,
                _concert.Payment,
                _concert.Comment);

            // Получаем восстановленный концерт с новым ID
            var all = _facade.GetAllConcerts();
            foreach (var c in all)
            {
                if (c.Name == _concert.Name && c.BandId == _concert.BandId)
                {
                    _concert = c;
                    break;
                }
            }
        }

        public ICommand CreateFresh() =>
            new DeleteConcertCommand(_facade, _concert);
    }

    public class DeleteContractCommand : ICommand
    {
        private readonly BandManagerFacade _facade;
        private Contract _contract;

        public string Description => $"Удаление контракта «{_contract.ProductName}»";

        public DeleteContractCommand(BandManagerFacade facade, Contract contract)
        {
            _facade = facade;
            _contract = contract;
        }

        public void Execute() => _facade.DeleteContract(_contract.Id);

        public void Undo()
        {
            _facade.CreateRecordingContract(
                _contract.StudioName,
                _contract.ResponsiblePerson,
                _contract.StartDate,
                _contract.EndDate,
                _contract.Payment,
                _contract.BandId,
                _contract.BandName,
                _contract.ProductName);

            // Получаем восстановленный контракт с новым ID
            var all = _facade.GetAllContracts();
            foreach (var c in all)
            {
                if (c.ProductName == _contract.ProductName
                    && c.BandId == _contract.BandId)
                {
                    _contract = c;
                    break;
                }
            }
        }

        public ICommand CreateFresh() =>
            new DeleteContractCommand(_facade, _contract);

        public class DeleteTourCommand : ICommand
        {
            private readonly BandManagerFacade _facade;
            private Tour _tour;

            public string Description => $"Удаление тура «{_tour.Name}»";

            public DeleteTourCommand(BandManagerFacade facade, Tour tour)
            {
                _facade = facade;
                _tour = tour;
            }

            public void Execute() => _facade.DeleteTour(_tour.Id);

            public void Undo()
            {
                string error = _facade.CreateTour(
                    _tour.Name,
                    _tour.BandId,
                    _tour.BandName,
                    _tour.StartDate,
                    _tour.EndDate,
                    _tour.Budget,
                    _tour.Country);

                if (error == null)
                {
                    var all = _facade.GetAllTours();
                    foreach (var t in all)
                    {
                        if (t.Name == _tour.Name && t.BandId == _tour.BandId)
                        {
                            _tour = t;
                            break;
                        }
                    }
                }
            }

            public ICommand CreateFresh() =>
                new DeleteTourCommand(_facade, _tour);
        }
    }
}