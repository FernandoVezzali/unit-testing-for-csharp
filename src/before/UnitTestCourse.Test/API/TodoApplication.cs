using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace UnitTestCourse.Test
{
    public class TodoApplication : WebApplicationFactory<Todo>
    {
        protected override IHost CreateHost(IHostBuilder builder)
        {
            var factory = new ConnectionFactory();

            var context = factory.CreateContextForSQLite();
            
            builder.ConfigureServices(services =>
            {
                services.AddScoped(sp =>
                {
                    return context;
                });
            });

            return base.CreateHost(builder);
        }
    }
}
