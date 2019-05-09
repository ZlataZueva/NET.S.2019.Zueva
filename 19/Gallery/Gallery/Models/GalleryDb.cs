namespace Gallery.Models
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class GalleryDb : DbContext
    {
        // Your context has been configured to use a 'GalleryDb' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'Gallery.Models.GalleryDb' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'GalleryDb' 
        // connection string in the application configuration file.
        public GalleryDb()
            : base("name=GalleryDb")
        {
            //Database.SetInitializer
            //    (new DropCreateDatabaseIfModelChanges<GalleryDb>());
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        public DbSet<Photo> Photos { get; set; }
    }
}