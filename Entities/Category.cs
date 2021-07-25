using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OnLineStore.Entities
{
    public class Category
    {
        [Key]
        public int categoryId { get; set; }
        public string categoryName { get; set; }

        public virtual ICollection<CatProp> catProps { get; set; }
        public  virtual ICollection<Device> devices  { get; set; }

    }
}
