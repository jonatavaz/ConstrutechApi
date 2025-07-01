using BLL;
using Construtech.Api.Routes;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

#region INJEÇÃO DE DEPENDÊNCIAS
builder.Services.AddScoped<PessoaBLL>();
builder.Services.AddScoped<UsuarioBLL>();
builder.Services.AddScoped<ObraBLL>();
builder.Services.AddScoped<ClienteBLL>();
builder.Services.AddScoped<ObraEquipamentoBLL>();
#endregion

var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
    app.UseSwagger();
    app.UseSwaggerUI();
//}

app.ConstrutechRoutes();


app.UseHttpsRedirection();
app.Run();

