using FormBuilder.Domain.Forms;

namespace FormBuilder.Domain.Shared;

public interface IAuditable
{
    public DateTime CreatedAt { get; }
    public DateTime? ModifiedAt { get; }
}