using IPMEDTH.Domain.Application.Models;
using IPMEDTH.Domain.Application.Services;
using IPMEDTH.Domain.Core.Repositories;
using IPMEDTH.Domain.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace IPMEDTH.Backend.Controllers
{

    [ApiController]
    [Route("/api/[controller]")]
    public class ScoresController : ControllerBase
    {
        private readonly IScoreService _service;

        public ScoresController(IScoreRepository scoreRepository)
        {
            this._service = new ScoreService(scoreRepository);
        }


        #region Create (C)
        [HttpPost]
        public ActionResult<ScoreModel> CreateScore([FromBody] ScoreModel model)
        {
            _service.Create(model);
            return Ok(model);
        }
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
        [HttpDelete("{id}")]
        public ActionResult DeleteById(string id)
        {
            _service.DeleteById(id);
            return Ok();
        }
        #endregion


    }
}
