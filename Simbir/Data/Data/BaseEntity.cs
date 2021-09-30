using System;

namespace Domain.Data
{
    public class BaseEntity
    {
        public int Id { get; set; }
        public DateTimeOffset? AddedDate { get; set; }
        public DateTimeOffset? ModifiedDate { get; set; }
        public byte[] Version { get; set; }
    }
}
