using System;
namespace FluentInterfaces.Events
{
    public class TrainableEventArgs : EventArgs
    {
        public DateTime TrainingDate { get; }
        public string Skill { get; }

        public TrainableEventArgs(string skill)
        {
            TrainingDate = DateTime.Now;
            Skill = skill;
        }
    }
}
