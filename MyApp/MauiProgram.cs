using System.IO;
using System.Reflection;

namespace MyApp
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

            // retrieving database file from embedded resources
            // IMP: this will refresh the database instance everytime the page is re-run, inspired by https://youtu.be/ftDq-leq5OM
            var assembly = IntrospectionExtensions.GetTypeInfo(typeof(App)).Assembly;
            using (Stream stream = assembly.GetManifestResourceStream("MyApp.data.db3"))
            {
                using (MemoryStream memoryStream = new())
                {
                    stream.CopyTo(memoryStream);
                    File.WriteAllBytes(AppRepository.DBpath, memoryStream.ToArray());
                }
            }

            // adding AppRepository as a singleton
            builder.Services.AddSingleton<AppRepository>(s => ActivatorUtilities.CreateInstance<AppRepository>(s));
            return builder.Build();
        }
    }
}