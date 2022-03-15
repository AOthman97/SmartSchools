namespace SmartSchools.Data
{
    public class SmartSchoolsDBContext
    {
        public SmartSchoolsDBContext()
        {

        }

        //public SmartSchoolsDBContext(dbcontextoptions options) : base(options)
        //{

        //}

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    if (!optionsBuilder.IsConfigured)
        //    {
        //        IConfigurationRoot configuration = new ConfigurationBuilder()
        //           .SetBasePath(Directory.GetCurrentDirectory())
        //           .AddJsonFile("appsettings.json")
        //           .Build();
        //        var connectionString = configuration.GetConnectionString("DefaultConnectionString");
        //        optionsBuilder.UseSqlServer(connectionString);
        //    }
        //}

        //// Each individual db set represents a table in our DB
        //public DbSet<Actor> Actors { get; set; }
        //public DbSet<Movie> Movies { get; set; }
        //public DbSet<Producer> Producers { get; set; }
        //public DbSet<Cinema> Cinemas { get; set; }
        //public DbSet<ActorsMovies> ActorsMovies { get; set; }
    }
}
