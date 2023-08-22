namespace SampleAPIWithAuthentication
{
    /// <summary>
    /// The entry point class for the application.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// The main method that starts the application.
        /// </summary>
        /// <param name="args">Command line arguments.</param>
        public static void Main(string[] args)
        {
            // Build the host and start the application
            CreateHostBuilder(args).Build().Run();
        }

        /// <summary>
        /// Creates a host builder for the application.
        /// </summary>
        /// <param name="args">Command line arguments.</param>
        /// <returns>An instance of <see cref="IHostBuilder"/>.</returns>
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    // Use the Startup class to configure the web host
                    webBuilder.UseStartup<Startup>();
                });
    }
}