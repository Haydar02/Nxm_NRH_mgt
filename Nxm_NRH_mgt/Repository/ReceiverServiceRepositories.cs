using Nxm_NRH_mgt.Models;
using Nxm_NRH_mgt.Nxm_Services;

namespace Nxm_NRH_mgt.Repository
{ public interface IReceiverServiceRepositories
    {
        List<ReceiverService> GetAll();
        ReceiverService Add(ReceiverService newReceiver);
        ReceiverService Delete(int id);
        ReceiverService Update(ReceiverService newReceiver, int id);
    }
    public class ReceiverServiceRepositories : IReceiverServiceRepositories
    {
        private IReceiverService_Services _service;

        public ReceiverServiceRepositories(IReceiverService_Services service)
        {
            _service = service;
        }

        public ReceiverService Add(ReceiverService newReceiver)
        {
            return _service.Add(newReceiver);
        }

        public ReceiverService Delete(int id)
        {
            return _service.Delete(id);
        }

        public List<ReceiverService> GetAll()
        {
            return _service.GetAll();
        }

        public ReceiverService Update(ReceiverService newReceiver, int id)
        {
            return _service.Update(newReceiver, id);

        }
    }
}
