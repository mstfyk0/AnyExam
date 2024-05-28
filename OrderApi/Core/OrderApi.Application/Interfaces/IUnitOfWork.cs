namespace OrderApi.Application.Interfaces

{
    public interface IUnitOfWork : IDisposable
    { 
        Task<bool> Commit(bool state = true);

    }
}
