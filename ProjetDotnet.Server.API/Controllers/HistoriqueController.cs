using Microsoft.AspNetCore.Mvc;
using ProjetDotnet.Enregistrement.Mapping;
using ProjetDotnet.Server.API.Services;

namespace ProjetDotnet.Server.API.Controllers
{
    [ApiController]
    [Route("api/historique")]
    public class HistoriqueController : Controller
    {
        private readonly HistoriqueService historiqueService;

        public HistoriqueController()
        {
            this.historiqueService = new HistoriqueService();
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<HistoriqueDto>>> GetHistorique()
        {
            return await historiqueService.GetHistorique();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<HistoriqueDto>> GetHistorique(int id)
        {
            var histDto = await historiqueService.GetHistoriqueById(id);

            if (histDto == null)
            {
                return NotFound();
            }

            return Ok(histDto);
        }
    }
}
