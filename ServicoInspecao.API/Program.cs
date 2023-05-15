using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using ServicoInspecao.API.Security;
using ServicoInspecao.Dominio.Interfaces.Repositories;
using ServicoInspecao.Dominio.Interfaces.Services;
using ServicoInspecao.Dominio.Services;
using ServicoInspecao.Infra.Repositories;
using System.Reflection.PortableExecutable;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//configuração de autenticação JWT
builder.Services.AddAuthentication(auth =>
        {
            auth.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            auth.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        }).AddJwtBearer(bearer =>
        {
            bearer.RequireHttpsMetadata = false;
            bearer.SaveToken = true;
            bearer.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(JwtSecurity.SecretKey)),
                ValidateIssuer = false,
                ValidateAudience = false
            };
        });

//mapeamento das injeções de dependencia ------------------------------------
builder.Services.AddScoped<IUsuarioDominioService, UsuarioDominioService>();
builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();
builder.Services.AddScoped<IInspecaoDominioService, InspecaoDominioService>();
builder.Services.AddScoped<IInspecaoRepository, InspecaoRepository>();
//builder.Services.AddTransient<IUsuarioDominioService, UsuarioDominioService>();
//builder.Services.AddTransient<IUsuarioRepository, UsuarioRepository>();
//builder.Services.AddTransient<IInspecaoDominioService, InspecaoDominioService>();
//builder.Services.AddTransient<IInspecaoRepository, InspecaoRepository>();
//mapeamento das injeções de dependencia ------------------------------------


//configuração de CORS
builder.Services.AddCors(
    s => s.AddPolicy("DefaltPolicy", builder =>
    {
        //.WithOrigins() //seta os enderecos que podem chamar sua p
        builder.AllowAnyOrigin() //qualqur servico de origem pode acessar a api
               .AllowAnyMethod()  //qualquer metodo (POST,PUT,DELE,GET)
               .AllowAnyHeader(); //qualquer parametro de cabecalho (HEADER)
    })
);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//configuraão de CORS
app.UseCors("DefaltPolicy");

//configurção da autentificação
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();
