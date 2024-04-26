using Nxm_NRH_mgt.Models;

namespace Nxm_NRH_mgt.Nxm_Services
{
    public interface IParticipantService
    {
        List<Participant>GetAll();
        Participant Add(Participant newParticipant);
        Participant Update(Participant update, int id);

        Participant Delete(int id);
    }
    public class ParticipantService : IParticipantService
    {

        private readonly Nxm_NRH_mgtContext _context;

        public ParticipantService(Nxm_NRH_mgtContext context)
        {
            _context = context;
        }

        public Participant Add(Participant newParticipant)
        {
            _context.Participants.Add(newParticipant);
            _context.SaveChanges();
            return newParticipant;
        }

        public Participant Delete(int id)
        {
            Participant foundItem = GetById(id);
            if (foundItem == null)
            {
                return null;
            }
            _context.Participants.Remove(foundItem);
            return foundItem;
        }

        public List<Participant> GetAll()
        {
            return _context.Participants.ToList();
        }

        public Participant Update(Participant update, int id)
        {
           Participant foundItem = GetById(id);
            if (foundItem == null)
            {
                return null;
            }
            foundItem.unitname = update.unitname;
            foundItem.unitcvr = update.unitcvr;
            foundItem.key = update.key;
            foundItem.keyType = update.keyType;
            return foundItem;
                
                
                }

        private Participant? GetById(int id)
        {
            return _context.Participants.Find(id);
        }
    }
}
