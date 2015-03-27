using Runner.Models;
using System;
using System.Collections.Generic;

namespace Runner.BLL
{
    public interface IUserProvider
    {
        void Add(User user);
        void Remove(Guid user);
        IEnumerable<User> GetAll();
        User Get(Guid id);
        void Update(User user);        
    }
}
