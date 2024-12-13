﻿using CSharpFunctionalExtensions;
using PetFamily.Domain.Volunteer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetFamily.Domain.Shared
{
    public record EntityId
    {
        public EntityId(Guid guid)
        {
            Value = guid;
        }
        public Guid Value { get; }
        public static EntityId NewEntityId() => new(Guid.NewGuid());
        public static EntityId Empty() => new(Guid.Empty);
    }
}
