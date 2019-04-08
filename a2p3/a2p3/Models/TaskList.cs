using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace a2p3.Models
{
    public class TaskList
    {
        [Key]
        public int TaskID { get; set; }

        [Required]
        [StringLength(50)]
        public string TaskName { get; set; }

        public bool TaskStatus { get; set; }

        [StringLength(100)]
        public string Description { get; set; }

    }
}
