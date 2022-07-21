using System;

namespace Db.Models
{
    public class UsersOrder
    {
        public Guid Id { get; set; }
        public double Price { get; set; }
        public DateTime CreatedDate { get; set; }
        public Guid CategoryId { get; set; }
        public Guid TariffId { get; set; }
        public Guid UserId { get; set; }
        public Guid OrderId { get; set; }
        public bool IsCompleted { get; set; }
        public bool IsExtended { get; set; }
    }
}
