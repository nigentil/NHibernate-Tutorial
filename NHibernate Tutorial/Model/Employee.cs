namespace NHibernate_Tutorial.Model
{
    public class Employee
    {
        public virtual int Id { get; set; }
        public virtual int IdJob { get; set; }
        public virtual string FirstName { get; set; }
        public virtual string LastName { get; set; }
        public virtual string Email { get; set; }

    }
}
