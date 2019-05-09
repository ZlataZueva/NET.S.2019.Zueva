using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Gallery.Models
{
    public class Photo
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Decription")]
        [Required]
        public string Description { get; set; }

        [Display(Name = "Image Path")]
        public string ImagePath { get; set; }

        [Display(Name = "Thumb Path")]
        public string ThumbPath { get; set; }

        //[Display(Name = "Created On")]
        //public DateTime CreatedOn { get; set; }

        //public Photo(int id, string description, string path, string thumbPath)
        //{
        //    this.Id = id;
        //    this.Description = description;
        //    this.ImagePath = path;
        //    this.ThumbPath = thumbPath;
        //    //this.CreatedOn = createdOn;
        //}

        public Photo()
        {

        }
    }
}