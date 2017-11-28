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
    [Table("LaborLog")]
    public class LaborLog:BaseModel
    {
        public DateTime StartShift { get; set; } = DateTime.Now;
        public DateTime? EndShift { get; set; }
        [Required]
        public string UserID { get; set; }

        [ForeignKey("UserID")]
        public virtual ApplicationUser User{ get; set; }
    }
}
