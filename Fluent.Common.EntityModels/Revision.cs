namespace Fluent.Models;

public class Revision
{
    private DateTime? dateCreated = null;
    public int Id { get; set; }
    public ICollection<FlashCard> FlashCards { get; set; } = null!;
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