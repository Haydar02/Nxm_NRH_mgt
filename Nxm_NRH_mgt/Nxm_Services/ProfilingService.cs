using Nxm_NRH_mgt.Models;

namespace Nxm_NRH_mgt.Nxm_Services
{
    public interface IProfilingService
    {
        List<Profiling> GetAll();
        Profiling Add(Profiling profiling);
        Profiling Delete(int id);

        Profiling Update(Profiling update, int id);
    }

    public class ProfilingService : IProfilingService
    {

        private readonly Nxm_NRH_mgtContext _context;

        public ProfilingService(Nxm_NRH_mgtContext context)
        {
            _context = context;
        }

        public Profiling Add(Profiling newProfiling)
        {
            _context.Profilings.Add(newProfiling);
            _context.SaveChanges();
            return newProfiling;

        }

        public Profiling Delete(int id)
        {
            Profiling foundItem = GetById(id);
            if (foundItem == null)
            {
                return null;
            }
            _context.Profilings.Remove(foundItem);
            _context.SaveChanges(true);
            return foundItem;
        }

        public List<Profiling> GetAll()
        {
            return _context.Profilings.ToList();
        }

        public Profiling Update(Profiling update, int id)
        {
            Profiling foundItem = GetById(id);
            if (foundItem == null)
            {
                return null;
            }
            foundItem.profilName = update.profilName;
            foundItem.businessId = update.businessId;
            _context.Profilings.Update(foundItem);
            _context.SaveChanges(true);
            return foundItem;
        }

        private Profiling GetById(int id)
        {
            return _context.Profilings.Find(id);
        }
    }
}
