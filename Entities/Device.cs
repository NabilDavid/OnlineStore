using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace OnLineStore.Entities
{
    public class Device
    {
        [Key]
        public int deviceId { get; set; }
        public string deviceName { get; set; }
      
        public DateTime acquisitionDate { get; set; }
        public string memo { get; set; }

        public int categoryId { get; set; }
        [ForeignKey("categoryId")]
        public Category Category { get; set; }
        public virtual ICollection<DevProp> devProps { get; set; }
    }
}
