using APIpractice.Model;
using FluentNHibernate.Mapping;

namespace APIpractice.Mappings
{
    public class CourseMap : ClassMap<Course>
    {
        public CourseMap()
        {
            Table("Course");
            Id(x => x.COURSE_ID);
            Map(x =>x.COURSE_NAME);
            Map(x => x.COURSE_CODE);
            Map(x => x.COURSE_DESC);
            Map (x => x.COURSE_SECTION);
            Map(x => x.CREDIT);
        }
    }
}
