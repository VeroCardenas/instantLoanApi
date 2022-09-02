using InstantLoan.DAL.Models;

namespace InstantLoan.BL.Repositories
{
    public interface IClientRepository
    {
        Task<IEnumerable<Client>> GetClients();
        Task<Client> GetClientById(int id);
        Task<Client> PostClient(Client dataClient);
        Task<Client> UpdateClient(int id, Client dataClient);
        Task<string> DeleteClientById(int id);
    }
}
