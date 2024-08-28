
using AppContext = _12LB.Model.AppContext;
//using User = _12LB.Model.User;
//AppContext appDb = new();
//User user1 = new()
//{
//    login = "Nikolay",
//    password = "Belyavskiy"
//};
//User user2 = new()
//{
//    login = "Fazom",
//    password = "Fazom1"
//};
//appDb.Users.Add(user1);
//appDb.Users.Add(user2);
//appDb.SaveChanges();



using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
string connection1 = "Host=localhost;Database=test_db;Username=postgres;Password=root";
builder.Services.AddDbContext<AppContext>(options => options.UseNpgsql(connection1));

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();



// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
