using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Collections.Models
{
    public class Comment
    {
        [Key]
        public int Id { get; set; }
        public string Text { get; set; }

        [ForeignKey("ItemComment")]
        [Required]
        public int ItemId { get; set; }
        public virtual Item ItemComment { get; set; }
        [ForeignKey("UserComment ")]
        [Required]
        public string UserId { get; set; }
        public virtual AppUser UserComment { get; set; }
    }
}
