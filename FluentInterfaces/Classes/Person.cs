using System;
using System.Collections.Generic;
using System.Text;
using FluentInterfaces.Events;
using FluentInterfaces.Interfaces;

namespace FluentInterfaces.Classes
{
    public class Person : ITrainable, ITrainingEvent, IDoEvent
    {
        #region Members

        private readonly IList<string> skills;

        #endregion Members

        #region Properties

        public string Name { get; }
        
        #endregion Properties

        #region Constructors

        public Person(string name)
        {
            Name = name;
            skills = new List<string>();
        }

        #endregion Constructors

        #region Implementation of ITrainable

        public ITrainable Train(string skill)
        {
            AddSkill(skill);
            return this;
        }

        public ITrainable Train(IEnumerable<string> skills)
        {
            foreach(var skill in skills)
            {
                AddSkill(skill);
            }
            return this;
        }

        public ITrainable Do(string skill)
        {
            PerformSkill(skill);
            return this;
        }

        public ITrainable Do(IEnumerable<string> skills)
        {
            foreach(var skill in skills)
            {
                PerformSkill(skill);
            }
            return this;
        }

        #endregion

        #region Overridden Methods

        #region Overrides of Object

        /// <summary>
        /// Returns a string that represents the current object.
        /// </summary>
        /// <returns>
        /// A string that represents the current object.
        /// </returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"Person {Name} has these skills:");
            foreach(var skill in skills)
            {
                sb.AppendLine($"\t*{skill}");
            }
            return sb.ToString();
        }

        #endregion

        #endregion Overridden Methods

        #region Implementation of ITrainingEvent

        public event EventHandler<TrainableEventArgs> TrainingHappened;

        #endregion

        #region Implementation of IDoEvent

        public event EventHandler<TrainableEventArgs> DoSkill;

        #endregion

        #region Helper Methods

        private void AddSkill(string skill)
        {
            if (skills.Contains(skill))
            {
                Console.WriteLine($"Already trained in {skill}.");
            }
            else
            {
                skills.Add(skill);
                TrainingHappened?.Invoke(this, new TrainableEventArgs(skill));
            }
        }

        private void PerformSkill(string skill)
        {
            if (!skills.Contains(skill))
            {
                Console.WriteLine($"Does not know {skill}.");
            }
            else
            {
                Console.WriteLine($"Performed {skill}.");
                DoSkill?.Invoke(this, new TrainableEventArgs(skill));
            }
        }

        #endregion Helper Methods
    }
}
