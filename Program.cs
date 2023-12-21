using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using laptopMarket.Data;
using laptopMarket.Repository.IRepository;
using laptopMarket.Repository;
using laptopMarket.ModelMapping;
using laptopMarket;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("laptopMarketContextConnection") ?? throw new InvalidOperationException("Connection string 'laptopMarketContextConnection' not found.");

builder.Services.AddDbContext<laptopMarketContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true).AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<laptopMarketContext>();
builder.Services.AddScoped<IuserRepo, UserRepo>();
builder.Services.AddScoped<Iproduct, ProductRepo>();
builder.Services.AddScoped<Icopon, coponRep>();
builder.Services.AddScoped<IwareHouse, warehouseRep>();
builder.Services.AddScoped<Icategory, CategoryRep>();
builder.Services.AddScoped<IserviceUserAdmin, serviceUserAdmin>();
builder.Services.AddScoped<IwarehouseProRepo, warehouseProRepo>();
builder.Services.AddScoped<IcartTableRepo, CartTableRepo>();
builder.Services.AddScoped<IcartItemRepo, CartItemRepo>();
builder.Services.AddScoped<IorderItem, OrderitemRepo>();
builder.Services.AddScoped<IorderTable, OrderTableRepo>();
builder.Services.AddAutoMapper(typeof(ModelMapping));
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
