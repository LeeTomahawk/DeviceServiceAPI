﻿using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public  class Identiti : AuditableEntity
    {
        public Guid Id { get; set; }
        public virtual Address Address { get; set; }
        public Guid AddressId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }

    }
}
