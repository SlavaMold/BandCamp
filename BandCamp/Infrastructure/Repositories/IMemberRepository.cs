using System.Collections.Generic;
using BandCamp.Models;

namespace BandCamp.Infrastructure.Repositories
{
    public interface IMemberRepository : IRepository<Member>
    {
        void AddMemberToBand(int memberId, int bandId);
        void RemoveMemberFromBand(int memberId, int bandId);
        List<Band> GetBandsByMemberId(int memberId);
    }
}