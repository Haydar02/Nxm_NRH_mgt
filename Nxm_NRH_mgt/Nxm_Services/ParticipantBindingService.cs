using Nxm_NRH_mgt.Models;

namespace Nxm_NRH_mgt.Nxm_Services
{ public interface IParticipantBindingService
    {
        List<ParticiPantBinding> GetAll();
        ParticiPantBinding Add(ParticiPantBinding newPantBinding);
        ParticiPantBinding Update(ParticiPantBinding update,int id);
        ParticiPantBinding Delete(int id);
    }
    public class ParticipantBindingService : IParticipantBindingService
    {
        private readonly Nxm_NRH_mgtContext _context;

        public ParticipantBindingService(Nxm_NRH_mgtContext context)
        {
            _context = context;
        }

        public ParticiPantBinding Add(ParticiPantBinding newPantBinding)
        {
            _context.ParticiPantBindings.Add(newPantBinding);
            _context.SaveChanges();
            return newPantBinding;
        }

        public ParticiPantBinding Delete(int id)
        {
            ParticiPantBinding foundItem = GetById(id);
            if (foundItem == null)
            {
                return null;
            }
            _context.ParticiPantBindings.Remove(foundItem);
            _context.SaveChanges ();
            return foundItem;
        }

        public List<ParticiPantBinding> GetAll()
        {
           return _context.ParticiPantBindings.ToList();
        }

        public ParticiPantBinding Update(ParticiPantBinding update, int id)
        {
            ParticiPantBinding foundItem = GetById(id);
            if (foundItem == null)
            {
                return null;
            }
            foundItem.networkTypeId = update.networkTypeId;
            foundItem.activationDate = update.activationDate;
            foundItem.expirationDate = update.expirationDate;
            foundItem.ownerparticipantId = update.ownerparticipantId;
            foundItem.ownercerviseId = update.ownercerviseId;
            return foundItem;
        }

        public ParticiPantBinding? GetById(int id)
        {
            return _context.ParticiPantBindings.Find(id);
        }
    }
}
