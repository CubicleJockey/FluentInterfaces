using System;
using FluentInterfaces.Events;

namespace FluentInterfaces.Interfaces
{
    public interface IDoEvent
    {
        event EventHandler<TrainableEventArgs> DoSkill;
    }
}