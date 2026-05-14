using System.Collections.Generic;
using BandCamp.Models;

namespace BandCamp.Infrastructure.Repositories
{
    public interface IConcertRepository : IRepository<Concert>
    {
        List<Concert> GetConcertsByBandId(int bandId);
    }
}