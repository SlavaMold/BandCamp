using System.Collections.Generic;
using BandCamp.Models;

namespace BandCamp.Infrastructure.Repositories
{
    public interface IContractRepository : IRepository<Contract>
    {
        List<Contract> GetContractsByBandId(int bandId);
        List<Contract> GetContractsByType(ContractType type);
    }
}