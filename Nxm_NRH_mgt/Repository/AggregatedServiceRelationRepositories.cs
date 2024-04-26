using Nxm_NRH_mgt.Models;
using Nxm_NRH_mgt.Nxm_Services;

namespace Nxm_NRH_mgt.Repository
{
    public interface IAggregatedServiceRelationRepositories
    {
        List<AggregatedServiceRelation> GetAll();
        AggregatedServiceRelation Add(AggregatedServiceRelation newRelation);
        AggregatedServiceRelation Update(AggregatedServiceRelation update, int id);
        AggregatedServiceRelation Delete(int id);
    }
    public class AggregatedServiceRelationRepositories : IAggregatedServiceRelationRepositories
    {
        private IAggregatedServiceRelationService _service;

        public AggregatedServiceRelationRepositories(IAggregatedServiceRelationService service)
        {
            _service = service;
        }

        public AggregatedServiceRelation Add(AggregatedServiceRelation newRelation)
        {
            return _service.Add(newRelation);
        }

        public AggregatedServiceRelation Delete(int id)
        {
            return _service.Delete(id);
        }

        public List<AggregatedServiceRelation> GetAll()
        {
            return _service.GetAll();
        }

        public AggregatedServiceRelation Update(AggregatedServiceRelation update, int id)
        {
            return _service.Update(update, id);
        }
    }
}
