﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Comment
    {
        [Key]
        public int CommentId { get; set; }

        [Display(Name = "Enter your comment :")]
        // [Range(5, 150, ErrorMessage = "Comment must be between 5 and 150 characters")]
        [MaxLength(1000), MinLength(5)]
        public string CommentContent { get; set; }
        public DateTime PostTime { get { return DateTime.Now; } }

        //TODO: Navigation Properties for user

    }
}