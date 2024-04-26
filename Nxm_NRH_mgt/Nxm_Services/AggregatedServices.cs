using Microsoft.EntityFrameworkCore;
using Nxm_NRH_mgt.Models;

namespace Nxm_NRH_mgt.Nxm_Services
{
    public interface IAggregatedService
    {
        List<AggregatedService> GetAll();
        AggregatedService Add (AggregatedService aggregatedService);
        AggregatedService Delete (int id);

        AggregatedService Update (AggregatedService update, int id );
    }
    public class AggregatedServices : IAggregatedService
    {
        private readonly Nxm_NRH_mgtContext _context;

        public AggregatedServices(Nxm_NRH_mgtContext context)
        {
            _context = context;
        }

        public AggregatedService Add(AggregatedService newAggregatedService)
        {
           
            _context.aggregatedServices.Add(newAggregatedService);
            _context.SaveChanges();
            return newAggregatedService;

        }

        public AggregatedService Delete(int id)
        {
            var profilId = _context.aggregatedServices.Find(id);
            if (profilId == null)
            {
                return null;
            }
            _context.aggregatedServices.Remove(profilId);
            _context.SaveChanges();
            return profilId;
            
        }

        public List<AggregatedService> GetAll()
        {
           return _context.aggregatedServices.ToList();
        }

        public AggregatedService Update(AggregatedService update, int id)
        {
            AggregatedService foundItem = GetById(id);
            if (foundItem == null)
            {
                return null;
            }
            foundItem.lastModified = update.lastModified;
            foundItem.lastModiFifiedBy = update.lastModiFifiedBy;
            _context.aggregatedServices.Update(foundItem);
            _context.SaveChanges();
            return foundItem;
       
        }

        private AggregatedService GetById(int id)
        {
            return _context.aggregatedServices.Find(id);
        }
    }
}
