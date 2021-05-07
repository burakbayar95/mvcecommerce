using Burak.Eticaret.Core.Model.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Burak.Eticaret.Core.Model
{
    public class EntityBase
    {
        [Key]
        [DataBaseGenerated(DatabaseGeneratedOption.Identity)]

        //her tabloda olması gereken
        public int ID { get; set; }
        public DateTime CreateDate  { get; set; }

        public int CreateUserID { get; set; }
        public DateTime? UpdateDate { get; set; }

        public int? UpdateUserID { get; set; }
        //boş bırakılabilir
    }
}
