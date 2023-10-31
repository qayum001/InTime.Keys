using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InTime.Keys.Infrastructure.Refit.InTimeModels.User
{
    public class InTimeUserProfile
    {
        public Guid Id { get; set; }
        public string Email { get; set; } = string.Empty;
        public bool HasNotificationSubscription { get; set; }
        public string NotificationSubscriptionEmail { get; set; } = string.Empty;
        public ICollection<UserRole> Roles { get; set; }
        public TsuAccountProfile TsuAccountProfile { get; set; }
        public BookingRole BookingRole { get; set; }
    }

    public enum UserRole
    {
        ADMIN,
        STAFF,
        STUDENT,
        BOOKING_USER
    }

    public class TsuAccountProfile
    {
        public Guid AccauntId { get; set; }
        public string LastName { get; set; }
        public string SecondName { get; set; }
        public string FirstName { get; set; }
        public string AvatarUrl { get; set; }
    }

    public class BookingRole
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Email { get; set; }
    }
}
