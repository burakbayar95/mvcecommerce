using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Burak.Eticaret.Core.Model.Entity
{
    internal class DataBaseGeneratedAttribute : Attribute
    {
        private DatabaseGeneratedOption ıdentity;

        public DataBaseGeneratedAttribute(DatabaseGeneratedOption ıdentity)
        {
            this.ıdentity = ıdentity;
        }
    }
}