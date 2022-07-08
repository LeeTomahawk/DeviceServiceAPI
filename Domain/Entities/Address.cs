﻿using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class Address : AuditableEntity
    {
        public Guid Id { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string Number { get; set; }
        public string PostCode { get; set; }
    }
}
