using GBank.Extensions;
using GBank.Graph;
using GBank.Repositories;
using GraphQL.MicrosoftDI;
using GraphQL.Server;
using GraphQL.Types;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace GBank
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IWebHostEnvironment environment)
        {
            Configuration = configuration;
            Environment = environment;
        }

        public IConfiguration Configuration { get; }
        public IWebHostEnvironment Environment { get; }
         
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<ISchema, GBankSchema>(services => new GBankSchema(new SelfActivatingServiceProvider(services)));
            services.AddSingleton<IAccountRepo, FakeAccountRepo>();
            services.AddSingleton<ICustomerRepo, FakeCustomerRepo>();

            services.AddScoped<ISchema, GBankSchema>()
                .AddGraphQL((options, provider) =>
                {
                    options.EnableMetrics = Environment.IsDevelopment();
                    var logger = provider.GetRequiredService<ILogger<Startup>>();
                    options.UnhandledExceptionDelegate = ctx => logger.LogError("{Error} occurred", ctx.OriginalException.Message);
                })
                .AddSystemTextJson(deserializerSettings => { }, serializerSettings => { })
                .AddErrorInfoProvider(opt => opt.ExposeExceptionStackTrace = Environment.IsDevelopment())
                .AddUserContextBuilder(context => new GraphQLUserContext(context.Request.Headers["authorization"]))
                .AddDataLoader()
                .AddGraphTypes(typeof(GBankSchema)); 

            services.AddGraphQLAuth((settings, provider) => settings.AddPolicy("AdminPolicy", p => p.RequireClaim("role", "Admin")));

        }
         
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            } 
            
            app.UseGraphQL<ISchema>();
            app.UseGraphQLAltair(); 
        }
    }
}
