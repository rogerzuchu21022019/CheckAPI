namespace SeaceDemo.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Comment
    {
        [Key]
        public int idComment { get; set; }

        [Required]
        [StringLength(255)]
        public string contentComment { get; set; }

        public int idPost { get; set; }

        [Required]
        [StringLength(255)]
        public string idUser { get; set; }

        public virtual Post Post { get; set; }

        public virtual User User { get; set; }
    }
}
