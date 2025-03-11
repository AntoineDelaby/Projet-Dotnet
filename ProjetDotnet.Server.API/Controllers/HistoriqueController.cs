using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
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

        // Récupère tous les enregistrements validés
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HistoriqueDto>>> GetHistorique()
        {
            return await historiqueService.GetHistorique();
        }

        // Récupère un enregistrement validé via son id
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

        // Génère un fichier JSON de l'historique des enregistrements validés
        [HttpPost("jsonHistory")]
        public async Task<ActionResult<int>> GenerateHistoriqueJson([FromBody] Dictionary<string, decimal> tauxDevises)
        {
            try
            {
                return Ok(await historiqueService.GenerateHistoriqueJson(tauxDevises));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
