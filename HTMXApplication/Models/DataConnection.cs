using Microsoft.EntityFrameworkCore;

namespace HTMXApplication.Models
{
    public class DataConnection : DbContext
    {
        public DataConnection()
        {

        }
        public DataConnection(DbContextOptions<DataConnection> options) : base(options)
        {

        }

        public DbSet<UsersModel> Users { get; set; }

        //Override the OnConfiguring method to read the connection string of database from SQL server via appsettings.json file
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var connectionString = configuration.GetConnectionString("DataConnection");
            optionsBuilder.UseSqlServer(connectionString);
        }
    }
}