using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Burak.Eticaret.Core.Model.Entity
{
  public  class UserAdress:EntityBase

    {
        public int UserID { get; set; }
        public User User { get; set; }//keyledi

        public string Title { get; set; }

        public string City { get; set; }
        public string Adress { get; set; }
        public bool IsActive { get; set; }
    }
}
