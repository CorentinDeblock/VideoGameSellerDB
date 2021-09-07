using Models.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Model
{
    public class OpinionModel
    {
        public int Id { get; set; }
        public OpinionType Type { get; set; }
        public DateTime PublishedAt { get; set; }

        public UserModel User { get; set; }
    }
}
