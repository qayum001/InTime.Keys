using JsonKnownTypes;

namespace InTime.Keys.Infrastructure.Refit.InTimeModels.Schedule
{
    [JsonKnownThisType("LESSON")]
    public class LessonGrid : EmptyLessonGrid
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public LessonType LessonType { get; set; }
        public IEnumerable<Group> Groups { get; set; }
        public Professor Professor { get; set; }
        public Audience Audience { get; set; }
    }

    public enum LessonType
    {
        LECTURE,
        PRACTICE,
        LABORATORY,
        SEMINAR,
        INDIVIDUAL,
        CONTROL_POINT,
        OTHER,
        DIFFERENTIAL_CREDIT,
        CREDIT,
        CONSULTATION,
        EXAM,
        BOOKING
    }

    public class Group
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public bool IsSubgroup { get; set; }
    }

    public class Professor
    {
        public Guid Id { get; set; }
        public string FullName { get; set; }
    }

    public class Audience
    {
        /// <summary>
        /// Id будет null если пара не очная
        /// </summary>
        public Guid? Id { get; set; }
        public string Name { get; set; }
        public string ShortName { get; set; }
        public Building Building { get; set; }
    }

    public class Building
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Adress { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }
}
