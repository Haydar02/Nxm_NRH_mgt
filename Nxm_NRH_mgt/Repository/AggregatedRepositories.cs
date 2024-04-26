using Nxm_NRH_mgt.Models;
using Nxm_NRH_mgt.Nxm_Services;

namespace Nxm_NRH_mgt.Repository
{
    public interface IAggregatedRepositpries
    {
        List<AggregatedService> GetAll();
        AggregatedService Add(AggregatedService aggregatedService);
        AggregatedService Delete(int id);

        AggregatedService Update(AggregatedService update, int id);
    }
    public class AggregatedRepositories : IAggregatedRepositpries
    {
        private IAggregatedService _service;

        public AggregatedRepositories(IAggregatedService service)
        {
            _service = service;
        }

        public AggregatedService Add(AggregatedService aggregatedService)
        {
            return _service.Add(aggregatedService);
        }

        public AggregatedService Delete(int id)
        {
            return _service.Delete(id);
        }

        public List<AggregatedService> GetAll()
        {
            return _service.GetAll();
        }

        public AggregatedService Update(AggregatedService update, int id)
        {
            return _service.Update(update, id);
        }
    }
}
