using Microsoft.AspNetCore.Identity;

namespace Collections.Models
{
    public class AppUser : IdentityUser
    {
        public virtual List<Collection> Collections { get; set; } = new List<Collection>();
        public virtual List<Item> Items { get; set; } = new List<Item>();
        public virtual List<Comment> Comments { get; set; } = new List<Comment>();
        
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
