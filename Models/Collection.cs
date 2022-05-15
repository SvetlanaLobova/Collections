using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Collections.Models
{
    public class Collection
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string? Description { get; set; }
        public CollectionTheme Theme { get; set; }
        public string? FieldName { get; set; }
        public FieldType? TypeField { get; set; }
        public string? FieldName1 { get; set; }
        public FieldType? TypeField1 { get; set; }
        public string? FieldName2 { get; set; }
        public FieldType? TypeField2 { get; set; }
        public virtual List<Item> Items { get; set; } = new List<Item>();

        [ForeignKey("AppUser")]
        [Required]
        public string UserCollectionId { get; set; }
        public AppUser AppUser { get; set; }
    }
    public enum CollectionTheme
    {
        [Display(Name = "Books")]
        Books,
        [Display(Name = "Stamps")]
        Stamps,
        [Display(Name = "Badges")]
        Badges,
        [Display(Name = "Alcohol")]
        Alcohol,
        [Display(Name = "Сoins")]
        Сoins,
        [Display(Name = "Magnets")]
        Magnets,
        [Display(Name = "Watches")]
        Watches,
        [Display(Name = "Postcards")]
        Postcards,
        [Display(Name = "Weapons")]
        Weapons
    }
    public enum FieldType
    {
        [Display(Name = "Numeric")]
        Numeric,
        [Display(Name = "String")]
        String,
        [Display(Name = "Text")]
        Text,
        [Display(Name = "Date")]
        Date,
        [Display(Name = "True/False")]
        TrueFalse
    }
    public static class GlobalCollection
    {
        public static int CollectionId { get; set; }
        public static string? FieldName { get; set; }
        public static FieldType? TypeField { get; set; }
        public static string? FieldName1 { get; set; }
        public static FieldType? TypeField1 { get; set; }
        public static string? FieldName2 { get; set; }
        public static FieldType? TypeField2 { get; set; }
    }
}
