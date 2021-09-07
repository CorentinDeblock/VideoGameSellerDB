using Microsoft.AspNetCore.Mvc;
using Models.Form;
using Models.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VideoGameSeller.API.Repositories.Bases;

namespace VideoGameSeller.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController
    {
        IRepository<UserModel, UserForm> Repository;
        IRepository<SaleTransactionModel, SaleForm> SaleTRepository;
        IRepository<SaleModel, SaleForm> SaleRepository;

        public UserController(
            IRepository<UserModel, UserForm> ur,
            IRepository<SaleTransactionModel, SaleForm> str,
            IRepository<SaleModel, SaleForm> sr
        )
        {
            Repository = ur;
            SaleTRepository = str;
            SaleRepository = sr;
        }

        [HttpPost]
        public UserModel Insert(UserForm user) {
            user.Grade = Models.Enum.GradeType.CLIENT;
            return Repository.Insert(user);
        }

        [HttpPost("Connect")]
        public UserModel Connect(UserConnectionForm form) => Repository.SingleCallProcedure("SPI_FindUser", form);

        [HttpGet("Historic/{userID}")]
        public IEnumerable<SaleTransactionModel> Historic(int userID) {
            IEnumerable<SaleTransactionModel> saleTransactions = SaleTRepository.GetMultiple(userID);
            IEnumerable<SaleTransactionModel> saleTransactionSale = SaleRepository.Search(new { Provider_Id = userID })
                .Select(s => new SaleTransactionModel { 
                    Price = s.Price,
                    Sale = s,
                    Type = (s.IsSale ? Models.Enum.SaleTransactionType.Sealed : Models.Enum.SaleTransactionType.Bid)
                });
            return saleTransactions.Concat(saleTransactionSale);
        }
    }
}
