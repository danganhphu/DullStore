//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DullStore.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("User")]

    public partial class User
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(100)]
        public string userName { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(100)]
        public string password { get; set; }
    }
}
