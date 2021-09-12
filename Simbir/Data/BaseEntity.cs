﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class BaseEntity
    {
        [Column("id")]
        public int Id { get; set; }
        [Column("added_date")]
        public DateTime? AddedDate { get; set; }
        [Column("modified_date")]
        public DateTime? ModifiedDate { get; set; }
    }
}