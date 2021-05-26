using System;

namespace DotzInc.Domain.Common
{
    public abstract class BaseEntityTraceable
    {
        public virtual int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? LastModifiedAt { get; set; }
    }
}
