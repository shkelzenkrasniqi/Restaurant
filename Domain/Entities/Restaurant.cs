using Domain.Base;

namespace Domain.Entities
{
    public class Restaurant : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public bool HasDelivery { get; set; }
        public string ContactEmail { get; set; }
        public string ContactNumber { get; set; }
        public Address Address { get; set; }
        public List<FoodItem> FoodItems { get; set; }
    }
}
