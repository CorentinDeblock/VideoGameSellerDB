using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Model
{
    public class PlatformModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Appearance { get; set; }

        public CompanyModel Company { get; set; }
        public PictureModel Picture { get; set; }
    }
}
