using Microsoft.EntityFrameworkCore;
using Refit;
using ToDoList.Data;
using ToDoList.Integrations;
using ToDoList.Integrations.Interfaces;
using ToDoList.Integrations.Refits;
using ToDoList.Repositories;
using ToDoList.Repositories.Interfaces;

namespace ToDoList
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddEntityFrameworkSqlServer()
                .AddDbContext<TaskSystemDBContext>(
                    options => options.UseSqlServer(builder.Configuration.GetConnectionString("DataBase"))
                );

            builder.Services.AddScoped<IUserRepository, UserRepository>();
            builder.Services.AddScoped<ITaskRepository, TaskRepository>();
            builder.Services.AddScoped<IViaCepIntegration, ViaCepIntegration>();
            builder.Services.AddRefitClient<IViaCepIntegrationRefit>().ConfigureHttpClient(client => {
                client.BaseAddress = new Uri("https://viacep.com.br");
            });

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
        }
    }
}