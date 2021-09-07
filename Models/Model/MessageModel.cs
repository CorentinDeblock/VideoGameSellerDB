using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Model
{
    public class MessageModel
    {
        public string Message { get; set; }
        public DateTime PublishedAt { get; set; }
        public UserModel User { get; set; }
        public IEnumerable<OpinionModel> Opinions { get; set; }
    }
}
