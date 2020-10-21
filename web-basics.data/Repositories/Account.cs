using Microsoft.Extensions.Configuration;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace web_basics.data.Repositories
{
    public class Account
    {
        WebBasicsDBContext context;

        public Account(IConfiguration configuration)
        {
            this.context = new WebBasicsDBContext(configuration);
        }

        public IEnumerable<Entities.Account> Get()
        {
            var accounts = context.Accounts.ToList();
            return accounts;
        }
        public void Delete(int id)
        {
            var account = context.Accounts.FirstOrDefault(m => m.Id == id);
            context.Accounts.Remove(account);
            context.SaveChanges();
        }
        public void Update(Entities.Account account)
        {
            context.Accounts.Update(account);
            context.SaveChanges();
        }
        public void Create(Entities.Account account)
        {
            context.Accounts.Add(account);
            context.SaveChanges();
        }
    }
}
