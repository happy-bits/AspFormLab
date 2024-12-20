using AspFormLab.Models;

namespace WebApp.ViewModels;

public class Group1Vm
{
    public List<Book> Books { get; set; } = [];
    public List<int> SelectedReviewIds { get; set; } = [];
}