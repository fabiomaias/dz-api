using System;

namespace DotzInc.Application.CQRS.Accounts.Shared
{
    public class AccountViewModel
    {
        public string AuthId { get; set; }
        public int Dz { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime LastModifiedAt { get; set; }
    }
}
