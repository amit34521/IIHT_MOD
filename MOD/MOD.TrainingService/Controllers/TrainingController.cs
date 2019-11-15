using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MOD.TrainingService.Models;
using MOD.TrainingService.Repository;

namespace MOD.TrainingService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrainingController : ControllerBase
    {
        private readonly ITrainingRepository _trainingRepository;

        public TrainingController(ITrainingRepository trainingRepository)
        {
            _trainingRepository = trainingRepository;
        }

        [HttpGet]
        public ActionResult<string> Get()
        {
            return Ok(_trainingRepository.GetAllTrainings());
        }

        // GET: api/Training/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(long id)
        {
            var result = _trainingRepository.GetTrainingById(id);
            if (result == null)
                return NoContent();
            return Ok(result);
        }

        [HttpGet("Mentor/{id}")]
        public ActionResult<string> GetByMentorId(long id)
        {
            var trainings = _trainingRepository.GetTrainingForMentorId(id);
            if(trainings != null && trainings.Count>0)
            {
                return Ok(trainings);
            }
            return NoContent();
        }

        [HttpGet("User/{id}")]
        public ActionResult<string> GetByUserId(long id)
        {
            var trainings = _trainingRepository.GetTrainingForUserId(id);
            if (trainings != null && trainings.Count > 0)
            {
                return Ok(trainings);
            }
            return NoContent();
        }

        // POST: api/Training
        [HttpPost]
        public void Post([FromBody] Training training)
        {
            _trainingRepository.AddTraining(training);
        }

        // PUT: api/Training/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Training training)
        {
            _trainingRepository.UpdateTraining(training);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(long id)
        {
            _trainingRepository.DeleteTraining(id);
        }
    }
}
