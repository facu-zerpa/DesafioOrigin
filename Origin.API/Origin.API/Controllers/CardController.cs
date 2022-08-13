using Microsoft.AspNetCore.Mvc;
using Origin.API.DTO;
using Origin.API.Repository.IRepository;
using Origin.API.Utils;

namespace Origin.API.Controllers
{
    [ApiController]
    [Route("api/card")]
    public class CardController: ControllerBase
    {
        private readonly ICardRepository cardRepository;
        private readonly IConfiguration configuration;

        public CardController(ICardRepository cardRepository, IConfiguration configuration)
        {
            this.cardRepository = cardRepository;
            this.configuration = configuration;
        }

        [HttpPost("verify/number")]
        public ActionResult VerifyNumber([FromBody] VerifyNumberDTO verifyNumberDTO)
        {
            var numberCard = verifyNumberDTO.Number;
            var card = cardRepository.VerifyNumberCard(numberCard).Result;
            if (card is null)
            {
                return NotFound(new { msj = "Numero de Tarjeta Incorrecta / Tarjeta Bloqueada"});
            }
            Crypto crypto = new Crypto(configuration["crypto:key"]);
            return Ok(new { Id = crypto.Encript(card.Id.ToString()) });
        }

        [HttpPost("verify/pin")]
        public ActionResult VerifyPin([FromBody] VerifyIdPinDTO verifyIdPinDTO)
        {
            var id = verifyIdPinDTO.Id;
            var pin = verifyIdPinDTO.Pin;
            var cardExist = cardRepository.VerifyPinCard(id, pin).Result;
            return cardExist ? Ok() : NotFound(new { msj = "Pin Incorrecto" });
        }

        [HttpPut("lock")]
        public ActionResult Lock([FromBody] LockPinDTO lockPinDTO)
        {
            var resultLock = cardRepository.LockCard(lockPinDTO.Id).Result;
            return resultLock ? Ok() : BadRequest();
        }
    }
}
