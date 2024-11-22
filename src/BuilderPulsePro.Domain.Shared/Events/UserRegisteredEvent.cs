using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuilderPulsePro.Events
{
    public class UserRegisteredEvent
    {
        public Guid UserId { get; set; }

        public UserRegisteredEvent(Guid userId)
        {
            UserId = userId;
        }
    }
}
