using Microsoft.AspNetCore.Mvc;
using Models;
using Models.Form;
using Models.Form.RelationForm;
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
    public class MessageController
    {
        IRepository<MessageModel, MessageForm> Repository;

        public MessageController(IRepository<MessageModel, MessageForm> repository)
        {
            Repository = repository;
        }

        [HttpGet]
        public IEnumerable<MessageModel> Get() => Repository.GetAll();

        [HttpPost("Opinion")]
        public OpinionModel Opinion(OpinionMessageForm form) => Repository.GetRepo<OpinionModel, OpinionMessageForm>("OpinionMessage").Insert(form);
    }
}
