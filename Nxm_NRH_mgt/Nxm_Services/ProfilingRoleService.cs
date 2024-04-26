using Nxm_NRH_mgt.Models;

namespace Nxm_NRH_mgt.Nxm_Services
{
    public interface IProfilingRoleService
    {
        List<ProfileRole> GetAll();
        ProfileRole Add(ProfileRole newProfileRole);
        ProfileRole Update(ProfileRole update, int id);
        ProfileRole Delete(int id);

    }
    public class ProfilingRoleService : IProfilingRoleService
    {
        private readonly Nxm_NRH_mgtContext _context;

        public ProfilingRoleService(Nxm_NRH_mgtContext context)
        {
            _context = context;
        }

        public ProfileRole Add(ProfileRole newProfileRole)
        {
            _context.ProfileRoles.Add(newProfileRole);
            _context.SaveChanges();
            return newProfileRole;
        }

        public ProfileRole Delete(int id)
        {
            ProfileRole foundItem = GetById(id);

            if (foundItem == null)
            {
                return null;
            }
            _context.ProfileRoles.Remove(foundItem);
            return foundItem;
        }

        public List<ProfileRole> GetAll()
        {
            return _context.ProfileRoles.ToList();
        }

        public ProfileRole Update(ProfileRole update, int id)
        {
            ProfileRole foundItem = GetById(id);
            if (foundItem == null)
            {
                return null;
            }
            foundItem.profilId = update.profilId;
            foundItem.profilingId = update.profilingId;
            foundItem.roleId = update.roleId;
            foundItem.documentStandardId = update.documentStandardId;
            _context.ProfileRoles.Update(foundItem);
            _context.SaveChanges(true);
            return foundItem;
        }

       private ProfileRole GetById(int id)
        {
            return _context.ProfileRoles.Find(id);
        }
    }
}
