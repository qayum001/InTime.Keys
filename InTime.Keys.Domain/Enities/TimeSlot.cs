using InTime.Keys.Domain.Common;

namespace InTime.Keys.Domain.Enities;

public sealed class TimeSlot : BaseAuditableEntity
{
    public int LessonNumber { get; private set; }
    public TimeSlot(Guid id, int lessonNumber)
        : base(id)
    {
        if (lessonNumber < 0 || lessonNumber > 7)
            throw new ArgumentOutOfRangeException("Lesson number must be in range [1;7]",nameof(LessonNumber));
        LessonNumber = lessonNumber;
    }
}
