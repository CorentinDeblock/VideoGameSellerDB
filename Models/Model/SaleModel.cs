using Models.Enum;
using Models.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Model
{
    public class SaleModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
        public bool IsSale { get; set; }
        public SaleType Type { get; set; }
        public DateTime PublishedAt { get; set; }

        public GameModel Game { get; set; }
        public UserModel User { get; set; }
        public IEnumerable<MessageModel> Messages { get; set; }
        public IEnumerable<OpinionModel> Opinions { get; set; }
        public IEnumerable<PictureModel> Pictures { get; set; }
        public IEnumerable<UserModel> Interested { get; set; }
    }
}
