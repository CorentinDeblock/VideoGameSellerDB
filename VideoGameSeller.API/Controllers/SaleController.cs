using Microsoft.AspNetCore.Mvc;
using Models;
using Models.Form;
using Models.Form.ProcedureForm;
using Models.Form.RelationForm;
using Models.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToolBox.Database;
using VideoGameSeller.API.Repositories.Bases;

namespace VideoGameSeller.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SaleController
    {
        IRepository<SaleModel, SaleForm> Repository;
        Connection _connection;
        public SaleController(IRepository<SaleModel, SaleForm> repository, Connection connection)
        {
            Repository = repository;
            _connection = connection;
        }

        [HttpGet]
        public IEnumerable<SaleModel> Get() => Repository.Search(new { IsSale = false });

        [HttpGet("{id}")]
        public SaleModel Get(int id) => Repository.Get(id);

        [HttpPost]
        public SaleModel Insert(SaleForm form) => Repository.Insert(form);

        [HttpPost("Message")]
        public MessageModel Insert(MessageSaleForm form) => Repository.GetRepo<MessageModel, MessageSaleForm>("SaleMessage").Insert(form);

        [HttpPost("Opinion")]
        public OpinionModel Insert(OpinionSaleForm form) => Repository.GetRepo<OpinionModel, OpinionSaleForm>("OpinionSale").Insert(form);

        [HttpPost("Picture")]
        public PictureModel Insert(PictureSaleForm form) => Repository.GetRepo<PictureModel, PictureSaleForm>("PictureSale").Insert(form);

        [HttpPost("UserInterest")]
        public UserModel Insert(UserSaleForm form) => Repository.GetRepo<UserModel, UserSaleForm>("UserSale").Insert(form);

        [HttpPost("BuySale")]
        public void Buy(SaleActionForm form) => new ProcedureCall("SP_BuySale", _connection).Call(form);

        [HttpPost("BidSale")]
        public void Bid(SaleBidForm form) => new ProcedureCall("SP_BidSale", _connection).Call(form);

        [HttpPost("ConfirmBid")]
        public void ConfirmBid(SaleActionForm form) => new ProcedureCall("SP_ConfirmBid", _connection).Call(form);
    }
}
