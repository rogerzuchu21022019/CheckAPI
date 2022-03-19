namespace SeaceDemo.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PhotoPost")]
    public partial class PhotoPost
    {
        [Key]
        public int idPhotoPost { get; set; }

        [StringLength(255)]
        public string srcPhotoPost { get; set; }

        public int idPost { get; set; }

        public virtual Post Post { get; set; }
    }
}
