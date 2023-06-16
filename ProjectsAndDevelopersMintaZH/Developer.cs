using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectsAndDevelopersMintaZH
{
    internal class Developer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [StringLength(100)]
        public string Name { get; set; }
        public bool IsStudent { get; set; }
        public int ProjectId { get; set; }
        [NotMapped]
        public virtual Project Project { get; set; }
    }
}
