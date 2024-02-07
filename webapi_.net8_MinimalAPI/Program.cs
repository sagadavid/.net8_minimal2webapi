var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

//Routing

app.MapGet("/shirts", () =>
{
    return "getting all shirts";
});

app.MapGet("/shirts/{id}", (int id) =>
{
    return $"getting shirt id: {id}";
});

app.MapPost("/shirts", () =>
{
    return "creating-posting all shirts";
});


app.MapPut("/shirts/{id}", (int id) =>
{
    return $"putting-updating shirt id: {id}";
});

app.MapDelete("/shirts/{id}", (int id) =>
{
    return $"deleting shirt id: {id}";
});


app.Run();

