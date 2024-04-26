using Nxm_NRH_mgt.Models;
using Nxm_NRH_mgt.Nxm_Services;

namespace Nxm_NRH_mgt.Repository
{
    public interface IProfilingRoleRepositories
    {
        List<ProfileRole> GetAll();
        ProfileRole Add(ProfileRole newProfileRole);
        ProfileRole Update(ProfileRole update, int id);
        ProfileRole Delete(int id);

    }
    public class ProfilingRoleRepositories : IProfilingRoleRepositories
    {
        private IProfilingRoleService _service;

        public ProfilingRoleRepositories(IProfilingRoleService service)
        {
            _service = service;
        }

        public ProfileRole Add(ProfileRole newProfileRole)
        {
            return _service.Add(newProfileRole);
        }

        public ProfileRole Delete(int id)
        {
            return _service.Delete(id);
        }

        public List<ProfileRole> GetAll()
        {
            return _service.GetAll();
        }

        public ProfileRole Update(ProfileRole update, int id)
        {
           return _service.Update(update, id);
        }
    }
}
