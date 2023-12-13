using AvaliacaoQuestor.Application.Interfaces;
using AvaliacaoQuestor.Application.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AvaliacaoQuestor.API.Controllers
{
    [Authorize]
    [ApiController]
    public class BoletosController : ControllerBase
    {
        private readonly IBoletoAppService _boletoAppService;

        public BoletosController(IBoletoAppService boletoAppService)
        {
            _boletoAppService = boletoAppService;
        }

        [HttpGet]
        [Route("api/boletos")]
        public ActionResult<IEnumerable<string>> Get()
        {
            try
            {
                var boletoViewModels = _boletoAppService.GetAllWithInterestPercentageCalculated();
                
                return Ok(boletoViewModels);
            } catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("api/boletos/{id}")]
        public ActionResult<string> Get(Guid id)
        {
            try
            {
                var boletoViewModel = _boletoAppService.GetByIdWithInterestPercentageCalculated(id);

                return Ok(boletoViewModel);
            } catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("api/boletos")]
        public ActionResult Post([FromBody] BoletoPostViewModel boletoPostViewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                _boletoAppService.Add(boletoPostViewModel);
            }
            catch(DbUpdateException ex)
            {
                return BadRequest("Erro ao inserir no banco de dados. Id do Banco provavelmente não existe ou data está em formato incorreto.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok("Boleto cadastrado com sucesso.");
        }
    }
}
