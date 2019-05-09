namespace Gallery.Migrations
{
    using Gallery.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Gallery.Models.GalleryDb>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
            ContextKey = "Gallery.Models.GalleryDb";
        }

        protected override void Seed(Gallery.Models.GalleryDb context)
        {
            context.Photos.AddOrUpdate(p => p.Description,
                new Photo
                {
                    Description = "roses",
                    ImagePath = "/Content/images/roses.jpg",
                    ThumbPath = "/Content/images/thumbnail/roses.jpg"
                },
                new Photo
                {
                    Description = "lilies",
                    ImagePath = "/Content/images/lilies.jpg",
                    ThumbPath = "/Content/images/thumbnail/lilies.jpg"
                },
                new Photo
                {
                    Description = "peonies",
                    ImagePath = "/Content/images/peonies.jpg",
                    ThumbPath = "/Content/images/thumbnail/peonies.jpg"
                },
                new Photo
                {
                    Description = "daisies",
                    ImagePath = "/Content/images/daisies.jpg",
                    ThumbPath = "/Content/images/thumbnail/daisies.jpg"
                },
                new Photo
                {
                    Description = "tulips",
                    ImagePath = "/Content/images/tulips.jpg",
                    ThumbPath = "/Content/images/thumbnail/tulips.jpg"
                });
        }
    }
}
