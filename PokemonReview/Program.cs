using Microsoft.EntityFrameworkCore;
using PokemonReview;
using PokemonReview.DataAccess;
using PokemonReview.DataAccess.Interfaces;
using PokemonReview.DataAccess.Repos;



var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddTransient<Seed>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddControllers().AddNewtonsoftJson();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new() { Title = "PokemonReview", Version = "v1", });

}).AddSwaggerGenNewtonsoftSupport();
builder.Services.AddEntityFrameworkNpgsql().AddDbContext<PokemonReviewDBContext>(options => options.UseNpgsql(builder.Configuration.GetConnectionString("PokemonReviewDbConnection")));

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
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
        service!.SeedPokemonReviewDBContext();
    }
}

// Configure the HTTP request pipeline.
// Always Exception handling middleware should be the first middleware in the pipeline to catch all exceptions that are thrown from there on.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage(); // Middleware for exception handling in development mode.
    app.UseSwagger(); // Enable middleware to serve generated Swagger(open-api doc) as a JSON endpoint.
    app.UseSwaggerUI(); // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), specifying the Swagger JSON endpoint.
}
else
{
    app.UseExceptionHandler("/error"); // Middleware for exception handling in production mode.
}


app.UseHttpsRedirection();

app.MapControllers();
app.Run();


