using APIpractice.Model;
using FluentNHibernate.Mapping;

namespace APIpractice.Mappings
{
    public class StudentMap : ClassMap<Student>
    {
        public StudentMap()
        {
            Table("student");
            Id(x => x.Id).GeneratedBy.Identity();
            Map(x => x.LastName);
            Map(x => x.FirstName);
        }
    }
}
