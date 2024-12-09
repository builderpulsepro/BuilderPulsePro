﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Uow;

namespace BuilderPulsePro.Builders
{
    public class BuilderCollaboratorInvitation : Entity<Guid>
    {
        public Guid BuilderProfileId { get; set; }
        public string EmailAddress { get; set; }
        public bool IsAccepted { get; set; }
        public DateTime InvitationDate { get; set; }
    }
}
