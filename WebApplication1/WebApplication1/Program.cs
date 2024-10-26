using Microsoft.AspNetCore.Http.HttpResults;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

var cus = new List<Customer>()
{
    new Customer(1, "gio", true)
};

app.MapGet("/cus", () => { return TypedResults.Ok(cus); });
app.MapGet("/cus/{id}", Ok<Customer> (int id) =>
{
    var customer = cus.SingleOrDefault(t => t.id == id);
    return TypedResults.Ok(customer);
});
app.Run();

public record Customer(int id, string name, bool isSatisfied);