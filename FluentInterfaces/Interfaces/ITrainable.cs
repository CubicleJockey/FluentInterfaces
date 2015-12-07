using System.Collections.Generic;

namespace FluentInterfaces.Interfaces
{
    public interface ITrainable
    {
        ITrainable Train(string skill);
        ITrainable Train(IEnumerable<string> skills);

        ITrainable Do(string skill);
        ITrainable Do(IEnumerable<string> skills);
    }
}
