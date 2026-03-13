using System.Collections.Generic;
using BandCamp.Models;

namespace BandCamp.Infrastructure.Repositories
{
    public interface IBandRepository : IRepository<Band>
    {
        List<Member> GetMembersByBandId(int bandId);
    }
}