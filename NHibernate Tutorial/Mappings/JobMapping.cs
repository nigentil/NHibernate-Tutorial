using FluentNHibernate.Mapping;

namespace NHibernate_Tutorial.Mappings
{
    public class JobMapping : ClassMap<Model.Job>
    {
        public JobMapping()
        {
            Id(x => x.Id);
            Map(x => x.JobName).Not.Nullable();
            Table("Job");
        }
    }
}
