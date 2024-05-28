namespace OrderApi.Application.Interfaces

{
    public interface IUnitOfWork : IDisposable
    { 
        bool Commit(bool state = true);
    }
}
