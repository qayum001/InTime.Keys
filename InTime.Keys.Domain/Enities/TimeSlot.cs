using InTime.Keys.Domain.Common;
using System.Diagnostics;

namespace InTime.Keys.Domain.Enities;

public class TimeSlot : BaseAuditableEntity
{
    public int LessonNumber { get; private set; }
    public DateTime Date { get; private set; }

    protected TimeSlot() {}

    public static TimeSlot Create(int lessonNumber, DateTime date)
    {
        if (lessonNumber < 0 || lessonNumber > 7)
            throw new ArgumentOutOfRangeException(nameof(LessonNumber), "Lesson number must be in range [1:7]");

        return new TimeSlot()
        {
            Id = Guid.NewGuid(),
            LessonNumber = lessonNumber,
            Date = date
        };
    }
}
