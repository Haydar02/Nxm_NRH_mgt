using Nxm_NRH_mgt.Models;
using Nxm_NRH_mgt.Nxm_Services;

namespace Nxm_NRH_mgt.Repository
{
    public interface IGroupRepositories
    {
        List<Groupp> GetGroups();

        Groupp Add(Groupp newGroup);
        Groupp update(Groupp update, int id);
        Groupp delete(int id);
    }
    public class GroupRepositories : IGroupRepositories
    {
        public IGroup_Service _groupService;

        public GroupRepositories(IGroup_Service groupService)
        {
            _groupService = groupService;
        }

        public Groupp Add(Groupp newGroup)
        {
            return _groupService.AddGroup(newGroup);
        }

        public Groupp delete(int id)
        {
            return _groupService.DeleteGroup(id);
        }

        public List<Groupp> GetGroups()
        {
           return _groupService.GetGroups();
        }

        public Groupp update(Groupp update, int id)
        {
            return _groupService.update(update, id);
        }
    }
}
