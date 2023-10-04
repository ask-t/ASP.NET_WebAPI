using APIpractice.Model;
using FluentNHibernate;
using FluentNHibernate.Conventions.Helpers;
using FluentNHibernate.Mapping;

namespace APIpractice.Mappings
{
    public class CourseProfessorMap : ClassMap<CourseProfessor>
    {
        public CourseProfessorMap()
        {
            Table("CourseProfessor");
            Id(x => x.COURSE_PROFESSOR_ID);
            Map(x => x.COURSE_ID);
            Map(x => x.PROFESSOR_ID);

        }

    }
}
