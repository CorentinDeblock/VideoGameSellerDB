using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Model
{
    public class GameModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Appearance { get; set; }
        public CompanyModel Developer { get; set; }
        public CompanyModel Publisher { get; set; }
        public PictureModel Picture { get; set; }
        public IEnumerable<PlatformModel> Platforms { get; set; }
    }
}
