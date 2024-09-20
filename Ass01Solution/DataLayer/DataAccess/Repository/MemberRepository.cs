using BussinessObject;

namespace DataAccess.Repository
{
    public class MemberRepository : IMemberRepository
    {
        public void AddMember(Member member) => MemberDAO.Instance.Add(member);

        public void DeleteMember(int id) => MemberDAO.Instance.Delete(id);

        public Member? GetMember(int id) => MemberDAO.Instance.GetMember(id);

        public Member? GetMember(string name) => MemberDAO.Instance.GetMember(name);

        public IEnumerable<Member> GetMembers() => MemberDAO.Instance.GetMembers();

        public Member? Login(string email, string password) => MemberDAO.Instance.Login(email, password);

        public void UpdateMember(Member member)=>MemberDAO.Instance.Update(member);
    }
}
