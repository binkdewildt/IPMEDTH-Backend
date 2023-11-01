using IPMEDTH.Domain.Application.Models;
using IPMEDTH.Domain.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace IPMEDTH.Backend.Controllers
{

    [ApiController]
    [Route("/api/[controller]")]
    public class ScoresController : ControllerBase
    {
        private readonly IScoreService _service;

        public ScoresController(IScoreService scoreService)
        {
            this._service = scoreService;
        }


        #region Create (C)
        #endregion


        #region Read (R)
        [HttpGet]
        public ActionResult<IEnumerable<ScoreModel>> GetAllScores()
        {
            return Ok(_service.GetAll());
        }

        [HttpGet("{id}")]
        public ActionResult<ScoreModel?> GetById(string id)
        {
            return Ok(_service.GetById(id));
        }
        #endregion


        #region Update (U)
        #endregion


        #region Delete (D)
        #endregion


    }
}
