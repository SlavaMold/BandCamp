using System.Collections.Generic;
using BandCamp.Infrastructure.Repositories;
using BandCamp.Models;

namespace BandCamp.Services
{
    public class MemberService
    {
        private readonly IMemberRepository _memberRepo;

        public MemberService(IMemberRepository memberRepo)
        {
            _memberRepo = memberRepo;
        }

        public List<Member> GetAllMembers() => _memberRepo.GetAll();

        public Member GetMemberById(int id) => _memberRepo.GetById(id);

        public void AddMember(Member member) => _memberRepo.Add(member);

        public void UpdateMember(Member member) => _memberRepo.Update(member);

        public void DeleteMember(int id) => _memberRepo.Delete(id);

        public void AddMemberToBand(int memberId, int bandId) =>
            _memberRepo.AddMemberToBand(memberId, bandId);

        public void RemoveMemberFromBand(int memberId, int bandId) =>
            _memberRepo.RemoveMemberFromBand(memberId, bandId);

        public List<Band> GetBandsByMemberId(int memberId) =>
            _memberRepo.GetBandsByMemberId(memberId);
    }
}