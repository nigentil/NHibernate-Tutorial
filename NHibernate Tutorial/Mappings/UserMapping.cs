using FluentNHibernate.Mapping;

namespace NHibernate_Tutorial.Mappings
{
    public class UsersMapping : ClassMap<Model.Users>
    {
        public UsersMapping()
        {
            Id(x => x.Id);
            Map(x => x.Name).Not.Nullable();
            Map(x => x.Login).Not.Nullable();
            Map(x => x.Password).Not.Nullable();
            Map(x => x.Status).Not.Nullable();
            Table("Users");
        }
    }
}
