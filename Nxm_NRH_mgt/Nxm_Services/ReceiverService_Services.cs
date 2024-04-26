using Nxm_NRH_mgt.Models;

namespace Nxm_NRH_mgt.Nxm_Services
{
    public interface IReceiverService_Services
    {
        List<ReceiverService> GetAll();
        ReceiverService Add(ReceiverService newReceiver);
        ReceiverService Delete(int id);
        ReceiverService Update(ReceiverService newReceiver,int id);
    }
    public class ReceiverService_Services: IReceiverService_Services
    {
        public readonly Nxm_NRH_mgtContext _context;

        public ReceiverService_Services(Nxm_NRH_mgtContext context)
        {
            _context = context;
        }

        public ReceiverService Add(ReceiverService newReceiver)
        {
            _context.ReceiverServices.Add(newReceiver);
            _context.SaveChanges();
            return newReceiver;
        }

        public ReceiverService Delete(int id)
        {
            ReceiverService founItem = GetById(id);
            if (founItem == null)
            {
                return null;
            }
            _context.ReceiverServices.Remove(founItem);
            _context.SaveChanges(true);
            return founItem;
        }

        public List<ReceiverService> GetAll()
        {
           return _context.ReceiverServices.ToList();
        }

        public ReceiverService Update(ReceiverService update, int id)
        {
           ReceiverService foundItem = GetById(id);
            if (foundItem == null)
            {
                return null;
            }
            foundItem.certificate = update.certificate;
            foundItem.contactName = update.contactName;
            foundItem.contactEmail = update.contactEmail;
            foundItem.endpointReference = update.endpointReference;
            _context.ReceiverServices.Update(foundItem);
            _context.SaveChanges();
            return foundItem;
        }
        private ReceiverService GetById(int id)
        {
            return _context.ReceiverServices.Find(id);
        }
    }
}
