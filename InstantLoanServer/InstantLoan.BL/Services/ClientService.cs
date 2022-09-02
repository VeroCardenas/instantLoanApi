using InstantLoan.BL.Repositories;
using InstantLoan.DAL;
using InstantLoan.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace InstantLoan.BL.Services
{
    public class ClientService: IClientRepository
    {
        private readonly ApiDbContext _context;

        // Creamos un constructor e inyectar el contexto
        public ClientService(ApiDbContext context)
        {
            _context = context;
        }


        // GET Clients
        public async Task<IEnumerable<Client>> GetClients()
        {
            var listClients = await _context.Client.ToListAsync();
            return listClients;
        }

        // GET Client By Id
        public async Task<Client> GetClientById(int id)
        {

            var clientFound = await _context.Client.FindAsync(id);
            return clientFound;
        }


        // POST Client
        public async Task<Client> PostClient(Client dataClient)
        {
            _context.Client.Add(dataClient);
            await _context.SaveChangesAsync();
            return dataClient;
        }


        // UPDATE
        public async Task<Client> UpdateClient(int id, Client dataClient)
        {
            _context.Client.Update(dataClient);
            await _context.SaveChangesAsync();
            return dataClient;
        }

        // DELETE
        public async Task<string> DeleteClientById(int id)
        {
            var clientFound = await _context.Client.FindAsync(id);
            if (clientFound == null)
            {
                return "NOT_FOUND";
            }
            _context.Client.Remove(clientFound);
            await _context.SaveChangesAsync();
            return "OK";
        }
    }
}
