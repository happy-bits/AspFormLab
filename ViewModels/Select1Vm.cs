using AspFormLab.Models;

namespace AspFormLab.ViewModels;

public class Select1Vm
{
    public IEnumerable<Author> Authors { get; set; } = [];
    public int? SelectedAuthorId { get; set; }
}