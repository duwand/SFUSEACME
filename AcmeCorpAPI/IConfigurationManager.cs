namespace AcmeCorpAPI
{
    static class IConfigurationManager
    {
        public static IConfiguration AppSetting { get; }
        static IConfigurationManager()
        {
            AppSetting = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json")
                    .Build();
        }
    }
}
