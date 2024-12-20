using AspFormLab.Models;

namespace AspFormLab.ViewModels;

public class Check1Vm
{
    public IEnumerable<Author> Authors { get; set; } = [];
    public List<int> SelectedAuthorIds { get; set; } = [];
}