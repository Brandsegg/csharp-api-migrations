using exercise.pizzashopapi.Models;

namespace exercise.pizzashopapi.Repository
{
    public interface IRepository
    {
        Task<IEnumerable<Order>> GetOrdersByCustomer(int id);
        Task<Order> CreateOrder(Order order);

        Task<List<Pizza>> GetPizzas();
        Task<Pizza> GetPizzaById(int id);
        Task<Customer> GetCustomerById(int id);
        Task<List<Customer>> GetCustomers();

        //Task<Order> GetOrders();

    }
}
