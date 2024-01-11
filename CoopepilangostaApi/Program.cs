using DataAccess.Data;
using Microsoft.EntityFrameworkCore;
using DataAccess;
using Newtonsoft.Json;
using AutoMapper;
using DataAccess.DTO;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using static DataAccess.DTO.ProducerOrderDTO;
using static DataAccess.DTO.ForesightProducerDTO;
using static DataAccess.DTO.CostumerOrderDTO;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddServices(builder.Configuration);
builder.Services.AddDataAccess(builder.Configuration);

//builder.Services.AddDbContext<ApiContext>(options =>
//options.UseSqlServer(builder.Configuration.GetConnectionString("CoopePilangostaBD") ??
//throw new InvalidOperationException("Connection string 'CoopePilangostaBD' not found.")));

builder.Services.AddDbContext<ApiContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("CopeBD") ??
throw new InvalidOperationException("Connection string 'CopeBD' not found.")));

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      policy =>
                      {
                          policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
                      });
});


builder.Services.AddControllers().AddNewtonsoftJson(options =>
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
);

var configuration = new MapperConfiguration(cfg =>
{
    cfg.AddProfile<CategoryMapper>();
    cfg.AddProfile<ProducerMapper>();
    cfg.AddProfile<ProductMapper>();
    cfg.AddProfile<ProductProducerMapper>();
    cfg.AddProfile<EntryMapper>();
    cfg.AddProfile<PurchaseMapper>();
    cfg.AddProfile<ProducerOrderMapper>();
    cfg.AddProfile<WarehouseMapper>();
    cfg.AddProfile<UserMapper>();
    cfg.AddProfile<ForesightMapper>();
    cfg.AddProfile<ForesightProducerDTOMapper>();
    cfg.AddProfile<CostumerMapper>();
    cfg.AddProfile<CostumerOrderMapper>();
    cfg.AddProfile<CostumerContactMapper>();
    cfg.AddProfile<EmployeeMapper>();
    cfg.AddProfile<StockReportMapper>();
    cfg.AddProfile<ProducerOrderMapper>();
    cfg.AddProfile<SaleMapper>();

});
var mapper = configuration.CreateMapper();

builder.Services.AddSingleton(mapper);


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//JWT Authentication
builder.Services.AddAuthentication(options =>
{
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.RequireHttpsMetadata = false;
    options.SaveToken = true;
    options.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("the secret key that is going to be used")),
        ValidateIssuer = false,
        ValidIssuer = "test",
        ValidateAudience = false,
        ValidAudience = "test",
        RequireExpirationTime = false,
        ValidateLifetime = false,
        ClockSkew = TimeSpan.FromDays(1),
    };
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseHttpsRedirection();

app.UseCors(MyAllowSpecificOrigins);


app.UseAuthorization();

app.MapControllers();

app.Run();
