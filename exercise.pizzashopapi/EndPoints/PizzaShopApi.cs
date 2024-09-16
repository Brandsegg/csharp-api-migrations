using exercise.pizzashopapi.Models;
using exercise.pizzashopapi.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace exercise.pizzashopapi.EndPoints
{
    public static class PizzaShopApi
    {
        public static void ConfigurePizzaShopApi(this WebApplication app)
        {
            var pizzaShop = app.MapGroup("pizzaShop");

            pizzaShop.MapGet("/pizza", GetPizzas);

            pizzaShop.MapGet("/customers/", GetCustomers);
            pizzaShop.MapGet("/customers/{id}", GetCustomer);

            pizzaShop.MapPost("/orders/{id}", GetOrder);
            pizzaShop.MapPost("/orders/{cid}+{pid}", AddOrder);
        }

        private static async Task<IResult> AddOrder(IRepository repo, int customerId, int pizzaId)
        {
            Customer customer = await repo.GetCustomerById(customerId);
            Pizza pizza = await repo.GetPizzaById(pizzaId);

            Order order = new Order();

            order.OrderTime = DateTime.Now;
            order.CustomerId = customerId;
            order.PizzaId = pizzaId;

            await repo.CreateOrder(order);
            return TypedResults.Ok(order);
        }

        private static async Task<IResult> GetCustomer(IRepository repo, int id)
        {
            var customer = await repo.GetCustomerById(id);
            return TypedResults.Ok(customer);
        }

        private static IResult GetOrder(IRepository repo)
        {
            throw new NotImplementedException();
        }

        private static async Task<IResult> GetCustomers(IRepository repo)
        {
            List<Customer> customers = await repo.GetCustomers();
            return TypedResults.Ok(customers);
        }

        private static IResult GetPizzas(IRepository repo)
        {
            return TypedResults.Ok(repo.GetPizzas());
        }
    }
}
