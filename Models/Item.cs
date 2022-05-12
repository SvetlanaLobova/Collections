using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Collections.Models
{
    public enum SortState
    {
        NameAsc,
        NameDesc,
        TagAsc,
        TagDesc,
    }
    public class Item
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Tag { get; set; }

        [ForeignKey("CollectionItem")]
        [Required]
        public int CollectionId { get; set; }
        public virtual Collection CollectionItem { get; set; }
        public int? SpecialInt { get; set; }
        public int? SpecialInt1 { get; set; }
        public int? SpecialInt2 { get; set; }
        public string? SpecialString { get; set; }
        public string? SpecialString1 { get; set; }
        public string? SpecialString2 { get; set; }
        public string? SpecialText { get; set; }
        public string? SpecialText1 { get; set; }
        public string? SpecialText2 { get; set; }
        public DateTime? SpecialDataType { get; set; }
        public DateTime? SpecialDataType1 { get; set; }
        public DateTime? SpecialDataType2 { get; set; }
        public bool? SpecialBool { get; set; }
        public bool? SpecialBool1 { get; set; }
        public bool? SpecialBool2 { get; set; }
    }
}
