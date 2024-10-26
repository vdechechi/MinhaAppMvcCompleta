using System;

namespace Business.Models
{
    public abstract class Entity // nao pode ser instanciada, precisa ser herdada
    {

        protected Entity()
        {
            Id = Guid.NewGuid();
        }
        public Guid Id { get; set; }
    }
}
