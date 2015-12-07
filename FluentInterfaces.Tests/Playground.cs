using System;
using FluentInterfaces.Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FluentInterfaces.Tests
{
    [TestClass]
    public class Playground
    {
        [TestMethod]
        public void ChainCommands()
        {
            var person = new Person("André");
            person.TrainingHappened += (sender, args) =>
            {
                var self = (Person) sender;
                Console.WriteLine($"{self.Name} trained {args.Skill} on {args.TrainingDate}.");
            };
            person.DoSkill += (sender, args) =>
            {
                var self = (Person) sender;
                Console.WriteLine($"{self.Name} performed {args.Skill} on {args.TrainingDate}.");
            };
            
            person.Train("Nunchucks")
                .Do("Ninja") //Don't know skill yet. No Event trigger
                .Train("Ninja")
                .Do("Ninja")
                .Train("Nunchucks")//Already trained, No event trigger
                .Do("Nunchucks"); 
        }

        [TestMethod]
        public void ChainCommands_IEnumerable_T()
        {
            var person = new Person("André");
            person.TrainingHappened += (sender, args) =>
            {
                var self = (Person)sender;
                Console.WriteLine($"{self.Name} trained {args.Skill} on {args.TrainingDate}.");
            };
            person.DoSkill += (sender, args) =>
            {
                var self = (Person)sender;
                Console.WriteLine($"{self.Name} performed {args.Skill} on {args.TrainingDate}.");
            };

            var skills = new[] {"Run", "Walk", "Swing", "Fly"};
            person.Train(skills).Do(skills);
        }
    }
}
