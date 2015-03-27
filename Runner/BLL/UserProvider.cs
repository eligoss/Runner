using Runner.DAL;
using Runner.Models;
using System;
using System.Collections.Generic;

namespace Runner.BLL
{
    public class UserProvider : IUserProvider
    {
        private readonly IXmlProvider _xmlProvider;

        public UserProvider(IXmlProvider provider)
        {
            this._xmlProvider = provider;
        }

        public void Add(User user)
        {
            this._xmlProvider.AddRecord(user);
        }

        public void Remove(Guid user)
        {
            this._xmlProvider.RemoveRecord(user);
        }

        public IEnumerable<User> GetAll()
        {
            return this._xmlProvider.GetAllRecords();
        }

        public void Update(User user)
        {
            this._xmlProvider.UpdateRecord(user);
        }

        public User Get(Guid id)
        {
            return this._xmlProvider.GetRecord(id);
        }
    }
}