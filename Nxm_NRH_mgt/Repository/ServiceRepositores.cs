using Nxm_NRH_mgt.Models;
using Nxm_NRH_mgt.NxmServices;

namespace Nxm_NRH_mgt.Repository
{
    public interface IServiceRepositores
    {
        List<ServicE> GetAll();
        ServicE AddService(ServicE newService);
        ServicE Delete(int id);
        ServicE Update(ServicE updates, int id);
        ServicE GetById(int id);
    }

    public class ServiceRepositores : IServiceRepositores
    {
       
        private IService _servises;

        public ServiceRepositores( IService servises)
        {
           
            _servises = servises;
        }

        public List<ServicE> GetAll()
        {
           return _servises.GetAll();
            
        }
       
        public ServicE AddService(ServicE newService)
        {
            return _servises.Add(newService);
        }

        public ServicE Delete(int id)
        {
            return _servises.Delete(id);
        }

        public ServicE Update(ServicE updates, int id)
        {
            return _servises.Update(updates, id);
        }

        public ServicE GetById(int id)
        {
            return _servises.GetById(id);
        }
    }
}
