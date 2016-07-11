using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using aspnetcoreapp.Models;
using Microsoft.AspNetCore.Mvc;

namespace aspnetcoreapp.Repositories
{
    public interface IDBContextRepository
    {
        void Delete(string id);
        Customer Get(string id);
        List<Customer> GetAll();
        void Post(Customer customerRecord);
        void Put(string id, [FromBody] Customer customerRecord);
    }
}
