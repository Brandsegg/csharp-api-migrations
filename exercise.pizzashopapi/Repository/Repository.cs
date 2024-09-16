using exercise.pizzashopapi.Data;
using exercise.pizzashopapi.Models;
using Microsoft.EntityFrameworkCore;

namespace exercise.pizzashopapi.Repository
{
    public class Repository : IRepository
    {
        private DataContext _db;

        public Repository(DataContext db)
        {
            _db = db;
        }

        public async Task<Customer> GetCustomerById(int id)
        {
            return await _db.Customers.FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<List<Customer>> GetCustomers()
        {
            return await _db.Customers.ToListAsync();
        }

       
        public async Task<IEnumerable<Order>> GetOrdersByCustomer(int id)
        {
            return await _db.Orders.Where(o => o.CustomerId == id).ToListAsync();
        }

        public async Task<Pizza> GetPizzaById(int id)
        {
            return await _db.Pizzas.FirstOrDefaultAsync(c => c.Id == id);    
        }

        public async Task<List<Pizza>> GetPizzas()
        {
            return await _db.Pizzas.ToListAsync();
        }

        public async Task<Order> CreateOrder(Order order)
        {
            await _db.AddAsync(order);
            await _db.SaveChangesAsync();
            return order;
        }
    }
}

