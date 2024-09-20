using BussinessObject;

namespace DataAccess.Repository
{
    public interface IMemberRepository
    {
        public IEnumerable<Member> GetMembers();
        public Member? GetMember(int id);
        public void DeleteMember(int id);
        public void AddMember(Member member);
        public void UpdateMember(Member member);
        public Member? Login(string email, string password);
        public Member? GetMember(string email);

    }
}
