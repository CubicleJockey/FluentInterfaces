using System;
using FluentInterfaces.Events;

namespace FluentInterfaces.Interfaces
{
    public interface ITrainingEvent
    {
        event EventHandler<TrainableEventArgs> TrainingHappened;
    }
}