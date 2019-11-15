using MOD.TrainingService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MOD.TrainingService.Repository
{
    public interface ITrainingRepository
    {
        List<Training> GetAllTrainings();
        void AddTraining(Training training);
        void UpdateTraining(Training Training);
        void DeleteTraining(long id);
        Training GetTrainingById(long id);
        List<Training> GetTrainingForMentorId(long id);

        List<Training> GetTrainingForUserId(long id);
    }
}
