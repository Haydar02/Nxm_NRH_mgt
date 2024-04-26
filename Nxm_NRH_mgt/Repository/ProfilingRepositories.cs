using Nxm_NRH_mgt.Models;
using Nxm_NRH_mgt.Nxm_Services;

namespace Nxm_NRH_mgt.Repository
{
    public interface IProfilingRepositories
    {
        List<Profiling> GetAll();
        Profiling Add(Profiling profiling);
        Profiling Delete(int id);

        Profiling Update(Profiling update, int id);
    }
    public class ProfilingRepositories : IProfilingRepositories
    {
        private IProfilingService _service;

        public ProfilingRepositories(IProfilingService service)
        {
            _service = service;
        }

        public Profiling Add(Profiling profiling)
        {
            return _service.Add(profiling);
        }

        public Profiling Delete(int id)
        {
            return _service.Delete(id);
        }

        public List<Profiling> GetAll()
        {
            return _service.GetAll();
        }

        public Profiling Update(Profiling update, int id)
        {
            return _service.Update(update, id);
        }
    }
}
