using OnLineStore.Entities;
using System.Collections.Generic;


namespace OnLineStore.DevCatVM
{
    public class DeviceCategoryVM
    {
       

        public Device device { get; set; }
        public List<DevProp> devProps { get; set; } 
       
    }
}
