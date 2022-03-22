namespace BlazorStaticDemo.Models;

public class IndexViewModel
{
    public string SalesPerson { get; set; } = string.Empty;
    public double Amount { get; set; }
    public bool IsActive { get; set; }
    public List<Location> Locations { get; set; } = new();
}
