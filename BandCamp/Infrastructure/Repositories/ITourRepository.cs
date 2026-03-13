using System.Collections.Generic;
using BandCamp.Models;

namespace BandCamp.Infrastructure.Repositories
{
    public interface ITourRepository : IRepository<Tour>
    {
        List<Tour> GetToursByBandId(int bandId);
    }
}