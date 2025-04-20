
using Microsoft.AspNetCore.Builder;

var sneakers = new List<Sneaker>
{
    new() { Name = "Nike Air", Color = "Black", Price = 120, Size = 42 },
    new Sneaker { Name = "Adidas Superstar", Color = "White", Price = 90, Size = 40 }
};

var app = WebApplication.Create();
app.MapGet("/sneakers", () => sneakers);

app.MapPost("/sneakers/add", (Sneaker newSneaker) =>
{
    sneakers.Add(newSneaker);
    return $"��������� {newSneaker.Name}!";
});

app.MapPost("/sneakers/delete", (string name) =>
{
    var sneaker = sneakers.FirstOrDefault(s => s.Name == name);
    if (sneaker != null)
    {
        sneakers.Remove(sneaker);
        return $"������� {name}!";
    }
    return "�� �������";
});

app.MapPost("/sneakers/edit", (Sneaker updatedSneaker) =>
{
    var sneaker = sneakers.FirstOrDefault(s => s.Name == updatedSneaker.Name);
    if (sneaker == null)
    {
        return "�� �������";
    }

    sneaker.Color = updatedSneaker.Color;
    sneaker.Price = updatedSneaker.Price;
    sneaker.Size = updatedSneaker.Size;

    return $"��������� {updatedSneaker.Name}!";
});


app.Run();


public class Sneaker
{
    public string Name { get; set; }
    public string Color { get; set; }
    public decimal Price { get; set; }
    public int Size { get; set; }
}