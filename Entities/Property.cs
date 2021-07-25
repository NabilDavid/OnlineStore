using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OnLineStore.Entities
{
    public class Property
    {
        [Key]
        public int propertyId { get; set; }
        public string propertyDesc { get; set; }
        public virtual ICollection<CatProp> catProps { get; set; }
        public virtual ICollection<DevProp> devProps { get; set; }

    }
}
