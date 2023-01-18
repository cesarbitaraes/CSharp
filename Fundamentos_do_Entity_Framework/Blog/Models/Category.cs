using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Blog.Models;

// [Table("Category")]
public class Category
{
    // Usando Data Annotations
    // [Key]
    // [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    // public int Id { get; set; }
    //
    // [Required]
    // [MinLength(3)]
    // [MaxLength(80)]
    // [Column("Name", TypeName = "NVARCHAR")]
    // public string Name { get; set; }
    //
    // [Required]
    // [MinLength(3)]
    // [MaxLength(80)]
    // [Column("Slug", TypeName = "VARCHAR")]
    // public string Slug { get; set; }
    
    // Usando Fluent Mapping

    public int Id { get; set; }
    public string Name { get; set; }
    public string Slug { get; set; }
    public IList<Post> Posts { get; set; }
}