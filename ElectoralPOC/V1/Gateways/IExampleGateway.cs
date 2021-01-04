using System.Collections.Generic;
using ElectoralPOC.V1.Domain;

namespace ElectoralPOC.V1.Gateways
{
    public interface IExampleGateway
    {
        Entity GetEntityById(int id);

        List<Entity> GetAll();
    }
}
