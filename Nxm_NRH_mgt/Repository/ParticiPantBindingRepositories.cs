using Nxm_NRH_mgt.Models;
using Nxm_NRH_mgt.Nxm_Services;

namespace Nxm_NRH_mgt.Repository
{
    public interface IParticiPantBindingRepositories
    {
        List<ParticiPantBinding> GetAll();
        ParticiPantBinding Add(ParticiPantBinding newPantBinding);
        ParticiPantBinding Update(ParticiPantBinding update, int id);
        ParticiPantBinding Delete(int id);
    }
    public class ParticiPantBindingRepositories : IParticiPantBindingRepositories
    {
        private IParticipantBindingService _service;

        public ParticiPantBindingRepositories(IParticipantBindingService servicce)
        {
            _service = servicce;
        }

        public ParticiPantBinding Add(ParticiPantBinding newPantBinding)
        {
            return _service.Add(newPantBinding);
        }

        public ParticiPantBinding Delete(int id)
        {
            return _service.Delete(id);

        }

        public List<ParticiPantBinding> GetAll()
        {
            return _service.GetAll();
        }

        public ParticiPantBinding Update(ParticiPantBinding update, int id)
        {
            return _service.Update(update, id);
        }
    }
}
