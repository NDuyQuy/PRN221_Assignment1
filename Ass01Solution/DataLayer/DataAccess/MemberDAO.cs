using BussinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    internal class MemberDAO
    {
        private static MemberDAO? instance;
        private static readonly object instanceLock = new object();
        public static MemberDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    instance ??= new MemberDAO();
                    return instance;
                }                
            }
        }

        public IEnumerable<Member> GetMembers() => new StoreContext().Members;

        public Member? GetMember(int id) => new StoreContext().Members.Find(id);
        public Member? GetMember(string email) => new StoreContext().Members.FirstOrDefault(c => c.Email == email);
        public void Add(Member member)
        {
            try
            {
                var dbContext = new StoreContext();
                dbContext.Members.Add(member);
                dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void Update(Member member)
        {
            try
            {
                var dbContext = new StoreContext();
                var _mem = GetMember(member.MemberId);
                if (_mem == null) throw new Exception("Member doesnt exist!");
                else
                {
                    member.Password = _mem.Password;
                    dbContext.Members.Update(member);
                    dbContext.SaveChanges();
                }
            }
            catch (Exception ex) 
            {
                throw new Exception(ex.Message);
            }
        }
        public void Delete(int id)
        {
            try
            {
                var dbContext = new StoreContext();
                var _mem = GetMember(id);
                if (_mem == null) throw new Exception("Member doesnt exist!");
                else
                {
                    dbContext.Members.Remove(_mem);
                    dbContext.SaveChanges();
                }
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public Member? Login(string email, string password) 
            => new StoreContext().Members.FirstOrDefault(c=>c.Email==email && c.Password == password);
    }
}
