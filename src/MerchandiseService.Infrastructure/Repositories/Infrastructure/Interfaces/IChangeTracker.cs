using System.Collections.Generic;
using MerchandiseService.Domain.Models;

namespace MerchandiseService.Infrastructure.Repositories.Infrastructure.Interfaces
{
    public interface IChangeTracker
    {
        IEnumerable<Entity> TrackedEntities { get; }
        
        public void Track(Entity entity);
    }
}