using System.ComponentModel.DataAnnotations.Schema;

namespace exercise.pizzashopapi.Models
{
    [Table("Orders")]
    public class Order
    {
        [Column("id")]
        public int Id { get; set; }
        [Column("pizzaId")]
        public int PizzaId { get; set; }
        [Column("customerId")]
        public int CustomerId { get; set; }
        [Column("date")]
        public DateTime OrderTime { get; set; }
        [Column("status")]
        public string Status { get; set; }
        public string UpdatePizzaStatus()
        {
            if (Status == "Delivered")
            {
                return Status;
            }

            double timePassed = DateTime.UtcNow.Subtract(OrderTime).TotalMinutes;

            if (timePassed < 3.0)
            {
                return "Preparing";
            }
            else if (timePassed < 15.0)
            {
                return "Cooking";
            }
            else
            {
                return "Delivering";
            }

        }
    }
}
