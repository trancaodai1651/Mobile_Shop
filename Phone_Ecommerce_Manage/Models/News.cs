﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Phone_Ecommerce_Manage.Models
{
    public partial class News
    {
        [Key]
        public int IdNews { get; set; }
        [StringLength(255)]
        public string Title { get; set; } = null!;
        [StringLength(255)]
        public string? DescriptionNew { get; set; }
        [Column(TypeName = "ntext")]
        public string? Content { get; set; }
        [StringLength(255)]
        [Unicode(false)]
        public string? Thumb { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? CreateDate { get; set; }
        public bool IsHot { get; set; }
        public int? IdCategoryNews { get; set; }
        public int? IdManager { get; set; }

        [ForeignKey("IdCategoryNews")]
        [InverseProperty("News")]
        public virtual CategoryNews? IdCategoryNewsNavigation { get; set; }
        [ForeignKey("IdManager")]
        [InverseProperty("News")]
        public virtual Manager? IdManagerNavigation { get; set; }
    }
}
