using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Net.Http.Headers;

namespace PandaSharp.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddPandaSharp(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddHttpClient<IPandaScoreClient, PandaScoreClient>(c =>
            {
                c.BaseAddress = new Uri(configuration.GetConnectionString("PandaScore:ApiUrl"));
                c.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", configuration.GetConnectionString("PandaScore:ApiToken"));
            });

            return services;
        }
    }
}
