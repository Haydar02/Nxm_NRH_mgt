using Nxm_NRH_mgt.Models;

namespace Nxm_NRH_mgt.Nxm_Services
{
    public interface IAggregatedServiceRelationService
    {
        List<AggregatedServiceRelation>GetAll();
        AggregatedServiceRelation Add(AggregatedServiceRelation newRelation);
        AggregatedServiceRelation Update(AggregatedServiceRelation update,int id);
        AggregatedServiceRelation Delete(int id);
    }
    public class AggregatedServiceRelationService : IAggregatedServiceRelationService
    {
        private readonly Nxm_NRH_mgtContext _context;

        public AggregatedServiceRelationService(Nxm_NRH_mgtContext context)
        {
            _context = context;
        }

        public AggregatedServiceRelation Add(AggregatedServiceRelation newrelation)
        {
            _context.AggregatedServiceRelations.Add(newrelation);
            _context.SaveChanges();
            return newrelation;
        }

        public AggregatedServiceRelation Delete(int id)
        {
            AggregatedServiceRelation founditem = GetById(id);
            if (founditem == null)
            {
                return null;
            }
            _context.AggregatedServiceRelations.Remove(founditem);
            _context.SaveChanges(true);
            return founditem;

        }

        public List<AggregatedServiceRelation> GetAll()
        {
           return _context.AggregatedServiceRelations.ToList();
        }

        public AggregatedServiceRelation Update(AggregatedServiceRelation update, int id)
        {
            AggregatedServiceRelation foundserviceRelation = GetById(id);
            if (foundserviceRelation == null)
            {
                return null;
            }
            foundserviceRelation.aggregatedServiceId = update.aggregatedServiceId;
            foundserviceRelation.receiverServiceId = update.receiverServiceId;
            return foundserviceRelation;
        }


        private AggregatedServiceRelation? GetById(int id)
        {
            return _context.AggregatedServiceRelations.Find( id);
        }
    }
}
