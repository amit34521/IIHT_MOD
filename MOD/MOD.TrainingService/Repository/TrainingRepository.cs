using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MOD.TrainingService.DBContexts;
using MOD.TrainingService.Models;

namespace MOD.TrainingService.Repository
{
    public class TrainingRepository : ITrainingRepository
    {
        private readonly TrainingContext trainingContext;

        public TrainingRepository(TrainingContext _trainingContext)
        {
            trainingContext = _trainingContext;
        }

        public void Save()
        {
            trainingContext.SaveChanges();
        }

        public void AddTraining(Training training)
        {
            training.mentorName = trainingContext.Mentors
                .Where(x => x.Id == training.mentorsId)
                .Select(y => (y.firstName + " " + y.lastName)).FirstOrDefault();
            training.userName = trainingContext.Users
                .Where(x => x.Id == training.userId)
                .Select(y => (y.firstName + " " + y.lastName)).FirstOrDefault();
            training.skillName = trainingContext.Skills.Find(training.skillId).Name;
            training.status = "N";
            training.progress = 0;
            trainingContext.Trainings.Add(training);
            Save();
        }

        public void DeleteTraining(long id)
        {
            var training = trainingContext.Trainings.Find(id);
            if(training != null)
            {
                trainingContext.Trainings.Remove(training);
                Save();
            }
        }

        public List<Training> GetAllTrainings()
        {
            return trainingContext.Trainings.ToList();
        }

        public Training GetTrainingById(long id)
        {
            return trainingContext.Trainings.Find(id);
        }

        public List<Training> GetTrainingForMentorId(long id)
        {
            return trainingContext.Trainings.Where(x => x.mentorsId == id).ToList();
        }

        public void UpdateTraining(Training Training)
        {
            var training = trainingContext.Trainings.Find(Training.Id);
            if(training != null)
            {
                training.status = "I";
                training.progress = Training.progress;
                Save();
            }
        }

        public List<Training> GetTrainingForUserId(long id)
        {
            return trainingContext.Trainings.Where(x => x.userId == id).ToList();
        }
    }
}
