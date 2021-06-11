namespace NHibernate_Tutorial.Model
{
    public class Users
    {
        public virtual int Id { get; set; }
        public virtual string Name { get; set;}
        public virtual string Login { get; set; }
        public virtual string Password { get; set; }
        public virtual string Status { get; set; }

    }
}
