using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace Collections.Models
{
    public class AppUser : IdentityUser
    {
        public virtual List<Collection> Collections { get; set; } = new List<Collection>();
        public Status Status { get; set; }
        public string UserRole { get; set; }
    }

    public enum Status
    {
        Active = 0,
        Blocked = 1
    }
    public static class GlobalAppUserId
    {
        public static string UserId { get; set; }
    }
}
