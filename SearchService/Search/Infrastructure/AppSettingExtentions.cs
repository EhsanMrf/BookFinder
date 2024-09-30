using Search.Infrastructure.Setting;

namespace Search.Infrastructure
{
    public static class AppSettingExtensions
    {
        public static void BindAppSettings(this IHostApplicationBuilder builder)
        {
            builder.Services.Configure<AppSettings>(builder.Configuration);
        }
    }
}
