using NHibernate;
using NHibernate.Criterion;
using NHibernate.Linq;
using System.Collections.Generic;
using System.Linq;

namespace NHibernate_Tutorial.Repository
{
    public class UserRepository 
    {

        public bool ValidateLogin(string login)
        {
            ISession session = SessionFactory.OpenSession;

            using (session)
            {
                return (from e in session.Query<Model.Users>() where e.Login.Equals(login) select e).Count() > 0;
            }
        }

        public bool ValidateAcess(string strLogin, string strPassword)
        {
            ISession session = SessionFactory.OpenSession;

            using (session)
            {

                IList<Model.Users> users = session.Query<Model.Users>().ToList()
                            .Where(x => x.Login == strLogin && x.Password == strPassword)
                            .OrderBy(c => (c.Id))
                            .ToList();

                foreach (var user in users)
                {
                    return true;
                }

                return false;
            }
        }
    }
}
