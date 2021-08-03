using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MongoDB.Bson.Serialization.Attributes;

namespace Vulder.SharedKernel
{
    public abstract class BaseEntity
    {
        [Key]
        [BsonId]
        public Guid Id { get; set; }

        [NotMapped]
        public List<BaseDomainEvent> Events { get; set; } = new();
    }
}