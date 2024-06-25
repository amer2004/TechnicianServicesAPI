using System.ComponentModel.DataAnnotations.Schema;

namespace TechnicalServicesAPI.Models
{
    public class Order
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public User.User User { get; set; }
        public long OrderNumber { get; set; }

        public int ExtendServiceId { get; set; }

        public ExtendService ExtendService { get; set; }

        public DateOnly Date { get; set; }

        public double XLocation { get; set; }

        public double YLocation { get; set; }

        public int? ChosenResponseId { get; set; }

        public Response? ChosenResponse { get; set; }

        [MaxLength(2000)]
        public string Description { get; set; }

        public int StatusId { get; set; }

        public OrderStatus Status { get; set; }

        public List<Response> Responses { get; set; }

    }
}
