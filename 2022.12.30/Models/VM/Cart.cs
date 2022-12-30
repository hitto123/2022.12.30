namespace _2022._12._30.Models.VM
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Cart
    {
        public int Id { get; set; }

        [Required]
        [StringLength(30)]
        public string MemberAccount { get; set; }
    }
}
