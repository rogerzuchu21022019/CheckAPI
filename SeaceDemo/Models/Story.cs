namespace SeaceDemo.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Story")]
    public partial class Story
    {
        [Key]
        public int idStory { get; set; }

        [Required]
        [StringLength(255)]
        public string contentStory { get; set; }

        public DateTime? timeStoryUp { get; set; }

        [StringLength(255)]
        public string srcImage { get; set; }

        [StringLength(255)]
        public string idUser { get; set; }

        public virtual User User { get; set; }
    }
}
