using Microsoft.EntityFrameworkCore;
using Nxm_NRH_mgt.Models;
using System.Text.RegularExpressions;


namespace Nxm_NRH_mgt.Nxm_Services
{
    public interface IGroup_Service
    {
        List<Groupp> GetGroups();

        Groupp AddGroup(Groupp newGroup);
        Groupp update (Groupp update, int id);
        Groupp DeleteGroup(int id );
        
            
    }
    public class Group_Service : IGroup_Service
    {
        private readonly Nxm_NRH_mgtContext _context;

        public Group_Service(Nxm_NRH_mgtContext context)
        {
            _context = context;
        }

        public Groupp AddGroup(Groupp newGroup)
        {
            _context.Groupps.Add(newGroup);
            _context.SaveChanges();
            return newGroup;
        }

        public Groupp DeleteGroup(int id)
        {
            Groupp foundGrooupp = GetById(id);
            if(foundGrooupp == null)
            {
                return null;
            }
            _context.Groupps.Remove(foundGrooupp);
            _context.SaveChanges();
            return foundGrooupp;
        }

        public List<Groupp> GetGroups()
        {
            return _context.Groupps.ToList();
        }

        public Groupp update(Groupp update, int id)
        {
            Groupp foundGroupp = GetById(id);
            if(foundGroupp == null)
            {
                return null;
            }
            foundGroupp.name = update.name;
            foundGroupp.contactName = update.contactName;
            foundGroupp.ownerGroupId = update.ownerGroupId;
            foundGroupp.ownerUddiBusinessId = update.ownerUddiBusinessId;
            _context.Groupps.Update(foundGroupp);
            _context.SaveChanges(true);
            return foundGroupp;
        }

        private Groupp GetById(int id)
        {
            return _context.Groupps.Find(id);
        }
    }
}
