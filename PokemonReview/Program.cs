using Microsoft.EntityFrameworkCore;
using PokemonReview.Data;
using PokemonReview;
using PokemonReview.Interfaces;
using PokemonReview.Repositories;



var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddTransient<Seed>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddControllers();
builder.Services.AddSwaggerGen();
builder.Services.AddEntityFrameworkNpgsql().AddDbContext<ApiDBContext>(options => options.UseNpgsql(builder.Configuration.GetConnectionString("PokemonReviewDbConnection")));

builder.Services.AddScoped<IPokemonRepo, PokemonRepo>();

var app = builder.Build();

if (args.Length == 1 && args[0].Equals("seeddata", StringComparison.CurrentCultureIgnoreCase))
    SeedData(app);

static void SeedData(IHost app)
{
    var scopedFactory = app.Services.GetService<IServiceScopeFactory>();

    using (var scope = scopedFactory!.CreateScope())
    {
        var service = scope.ServiceProvider.GetService<Seed>();
        service!.SeedApiDBContext();
    }
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger(); // Enable middleware to serve generated Swagger(open-api doc) as a JSON endpoint.
    app.UseSwaggerUI(); // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), specifying the Swagger JSON endpoint.
}

app.UseHttpsRedirection();

app.MapControllers();
app.Run();


