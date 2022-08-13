using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Origin.API.DTO;
using Origin.API.Entities;
using Origin.API.Repository.IRepository;
using Origin.API.Utils;

namespace Origin.API.Controllers
{
    [ApiController]
    [Route("api/operation")]
    public class OperationController: ControllerBase
    {
        private readonly ICardRepository cardRepository;
        private readonly IOperationRepository operationRepository;
        private readonly IConfiguration configuration;
        private readonly IMapper mapper;

        public OperationController(
            ICardRepository cardRepository, 
            IOperationRepository operationRepository, 
            IConfiguration configuration,
            IMapper mapper)
        {
            this.cardRepository = cardRepository;
            this.operationRepository = operationRepository;
            this.configuration = configuration;
            this.mapper = mapper;
        }

        [HttpPost("balance")]
        public ActionResult Balance([FromBody] BalanceDTO balanceDTO)
        {
            var id = balanceDTO.Id;
            var card = cardRepository.GetCard(id).Result;
            if (card is null)
            {
                return NotFound(new { msj = "Tarjeta invalida / Pin Bloqueado"});
            }

            var result = operationRepository.InsertOperationBalance(new Operation
            {
                CardId = card.Id,
                TypeOperationId = (int) TypesOperations.Balance,
                Date = DateTime.Now,
                Code = Guid.NewGuid().ToString(),
            }).Result;

            if (!result)
            {
                return BadRequest();
            }
            
            var dto = mapper.Map<ResponseBalanceDTO>(card);
            
            return Ok(dto);
        }

        [HttpPost("withdraw")]
        public ActionResult Withdraw([FromBody] WithDrawDTO withDrawDTO)
        {
            var id = withDrawDTO.Id;
            var amount = withDrawDTO.Ammount;
            
            var card = cardRepository.GetCard(id).Result;

            if (card.Balance.CompareTo(amount) == -1)
            {
                return BadRequest(new { msj = "No cuenta con el suficiente saldo en su cuenta" });
            }
            
            var discountBalance = cardRepository.DiscountBalance(id, amount).Result;
            
            if (!discountBalance)
            {
                return BadRequest();
            }

            var operation = operationRepository.InsertOperationWidtdraw(new Operation
            {
                CardId = card.Id,
                TypeOperationId = (int) TypesOperations.Withdraw,
                Date = DateTime.Now,
                Code = Guid.NewGuid().ToString(),
                Amount = amount,
            }).Result;

            if (operation is null)
            {
                return BadRequest();
            }

            var dto = mapper.Map<ResponseWithdrawDTO>(operation);

            return Ok(dto);
        }

    }
}
