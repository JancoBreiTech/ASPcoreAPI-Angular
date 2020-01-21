﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entities.Models
{
    [Table("Owner")]
    public class Owner
    {
        [Column("OwnerId")]
        public Guid Id { get; set; }

        [Required(ErrorMessage ="Name is required")]
        [StringLength(50, ErrorMessage ="Must be less than 50 characters")]
        [Column("Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Address is required")]
        [StringLength(50, ErrorMessage = "Must be less than 50 characters")]
        public string Address { get; set; }

        [Required(ErrorMessage ="Date Of Birth is required")]
        [Column("DayeOfBirth")]
        public DateTime DateOfBirth { get; set; }

        public ICollection<Account> Accounts { get; set; }
    }
}
