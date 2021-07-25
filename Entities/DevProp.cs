using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace OnLineStore.Entities
{
    public class DevProp
    {
        [Key, Column(Order = 0)]
        public int propertyId { get; set; }
        [Key, Column(Order = 1)]
        public int deviceId { get; set; }

        public string value { get; set; }

        [ForeignKey("propertyId")]
        public Property property { get; set; }
        [ForeignKey("deviceId")]
        public Device device { get; set; }
    }
}
