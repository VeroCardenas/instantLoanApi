﻿using InstantLoan.DAL.Models;

namespace InstantLoan.BL.Repositories
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetUsers();
        Task<User> GetUserById(int id);
        Task<User> PostUser(User dataUser);
        Task<User> UpdateUser(int id, User dataUser);
        Task<string> DeleteUserById(int id);
    }
}
