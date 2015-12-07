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

        private readonly IList<string> _skills;

        #endregion Members

        #region Properties

        public string Name { get; }
        
        #endregion Properties

        #region Constructors

        public Person(string name)
        {
            Name = name;
            _skills = new List<string>();
        }

        #endregion Constructors

        #region Implementation of ITrainable

        public ITrainable Train(string skill)
        {
            if(_skills.Contains(skill))
            {
                Console.WriteLine($"Already trained in {skill}.");
            }
            else
            {
                _skills.Add(skill);
                TrainingHappened?.Invoke(this, new TrainableEventArgs(skill));
            }
            return this;
        }

        public ITrainable Do(string skill)
        {
            if(!_skills.Contains(skill))
            {
                Console.WriteLine($"Does not know {skill}.");
            }
            else
            {
                Console.WriteLine($"Performed {skill}.");
                DoSkill?.Invoke(this, new TrainableEventArgs(skill));
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
            foreach(var skill in _skills)
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
    }
}
