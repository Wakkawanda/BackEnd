using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

using System.DirectoryServices.Protocols;
using System.Net;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;

namespace BackEnd;

class Program
{
    private static Settings.Settings s;

    static void Main(string[] args)
    {
        string d = File.ReadAllText("C:\\Users\\verao\\Desktop\\BackEnd\\BackEnd\\BackEnd\\Configuration.json");
        s = JsonConvert.DeserializeObject<Settings.Settings>(d)!;

        var builder = WebApplication.CreateBuilder(args);

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

        app.UseAuthorization(); // Может понадобиться для авторизации.  Пока не используется, но лучше оставить

        app.MapControllers();

        app.Run();
    }

    public void conLdap()
    {
        string uname = "i22s0659";
        string password = "kNpcqHrW";
        
        LdapConnection connection = new LdapConnection(s.LdapIp);
        connection.Credential = new NetworkCredential(uname, password);
        
        connection.Bind();
        connection.Dispose();
        
    }
}