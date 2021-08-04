using System;

namespace Locadora.Domain.Models
{
    public abstract class Entity
    {
        public Entity()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }
        public bool Ativo { get; set; }
    }
}
