using System.Collections.Generic;
using System.Linq;
using aspnetcoreapp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using aspnetcoreapp.Repositories;


namespace aspnetcoreapp.Repositories
{
    public class DBContextRepository : IDBContextRepository
    {
        private readonly DBContext _context;
        private readonly ILogger _logger;

        public DBContextRepository(DBContext context, ILoggerFactory loggerFactory)
        {
            _context = context;
            _logger = loggerFactory.CreateLogger("IDataEventRecordResporitory");
        }

        public List<Customer> GetAll()
        {
            _logger.LogCritical("Getting a the existing records");
            return _context.Customers.ToList();
        }

        public Customer Get(string id)
        {
            return _context.Customers.First(t => t.Id == id);
        }

        [HttpPost]
        public void Post(Customer customerRecord)
        {
            _context.Customers.Add(customerRecord);
            _context.SaveChanges();
        }

        public void Put(string id, [FromBody]Customer customerRecord)
        {
            _context.Customers.Update(customerRecord);
            _context.SaveChanges();
        }

        public void Delete(string id)
        {
            var entity = _context.Customers.First(t => t.Id == id);
            _context.Customers.Remove(entity);
            _context.SaveChanges();
        }
    }

}
