using Nxm_NRH_mgt.Models;
using Nxm_NRH_mgt.Nxm_Services;

namespace Nxm_NRH_mgt.Repository
{
    public interface IParticipantRepositories
    {
    List<Participant> GetAll();
    Participant Add(Participant newParticipant);
    Participant Update(Participant update, int id);

    Participant Delete(int id);
    }
    public class ParticipantRepositories : IParticipantRepositories
    {
        private IParticipantService _service;

        public ParticipantRepositories(IParticipantService service)
        {
            _service = service;
        }

        public Participant Add(Participant newParticipant)
        {
            return _service.Add(newParticipant);
        }

        public Participant Delete(int id)
        {
            return _service.Delete(id);
        }

        public List<Participant> GetAll()
        {
            return _service.GetAll();
        }

        public Participant Update(Participant update, int id)
        {
            return _service.Update(update, id);
        }
    }
}
