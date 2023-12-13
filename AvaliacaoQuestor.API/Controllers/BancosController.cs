using AvaliacaoQuestor.Application.Interfaces;
using AvaliacaoQuestor.Application.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AvaliacaoQuestor.API.Controllers
{
    [Authorize]
    [ApiController]
    public class BancosController : ControllerBase
    {
        private readonly IBancoAppService _bancoAppService;

        public BancosController(IBancoAppService bancoAppService)
        {
            _bancoAppService = bancoAppService;
        }

        [HttpGet]
        [Route("api/bancos")]
        public ActionResult<IEnumerable<string>> Get()
        {
            return Ok(_bancoAppService.GetAll());
        }

        [HttpGet]
        [Route("api/bancos/{id}")]
        public ActionResult<string> Get(Guid id)
        {
            return Ok(_bancoAppService.GetById(id));
        }

        [HttpPost]
        [Route("api/bancos")]
        public ActionResult Post([FromBody] BancoPostViewModel bancoPostViewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                _bancoAppService.Add(bancoPostViewModel);
            } catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok("Banco cadastrado com sucesso.");
        }
    }
}
