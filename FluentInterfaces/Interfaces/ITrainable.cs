namespace FluentInterfaces.Interfaces
{
    public interface ITrainable
    {
        ITrainable Train(string skill);
        ITrainable Do(string skill);
    }
}
