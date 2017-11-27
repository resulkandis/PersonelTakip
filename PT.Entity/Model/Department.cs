using PT.Entity.IdentityModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PT.Entity.Model
{
    [Table("Departmans")]
    public class Department:BaseModel
    {
        [Required]
        [StringLength(55,ErrorMessage ="Bu alan Zorunludur",MinimumLength =5)]
        [Index(IsUnique =true)] // ikinci bir departman adı tablosu oluşmasın diye
        public string DepartmantName { get; set; }

        public virtual List<ApplicationUser> Users { get; set; } = new List<ApplicationUser>();

    }
}
