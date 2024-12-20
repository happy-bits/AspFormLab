using AspFormLab.Models;

namespace AspFormLab.ViewModels;

public class Check1Vm
{
    public IEnumerable<Author> Authors { get; set; } = [];
    public List<int> SelectedAuthorIds { get; set; } = [];


    public List<AuthorCheckboxVm> SelectedAuthors { get; set; } = [];
    
}

public class AuthorCheckboxVm
{
    public int Id { get; set; }
    public string Name { get; set; }="";
    public bool IsSelected { get; set; }
}