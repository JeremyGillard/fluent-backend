using System.ComponentModel.DataAnnotations;

namespace Fluent.Models;

public class FlashCard
{
    private DateTime? dateCreated = null;
    public int Id { get; set; }
    [Required]
    [StringLength(256)]
    public string Word { get; set; } = null!;
    [Required]
    [StringLength(256)]
    public string? Translation { get; set; } = null!;
    public ICollection<Revision> Revisions { get; set; } = null!;
    public DateTime CreationDate
    {
        get
        {
            return this.dateCreated.HasValue
                ? this.dateCreated.Value
                : DateTime.Now;
        }
        set { this.dateCreated = value; }
    }
}