using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System.Collections.Generic;
using Nxm_NRH_mgt.Models;
using System.Linq;

namespace Nxm_NRH_mgt.NxmServices
{
    public interface IService
    {
        List<ServicE> GetAll();
        ServicE Add(ServicE newservice);  
        ServicE Update(ServicE service, int id);
        ServicE Delete(int id);
        ServicE GetById(int id);

    }
    public class Service : IService
    {
        private readonly Nxm_NRH_mgtContext _context;

        public Service(Nxm_NRH_mgtContext context)
        {
            _context = context;
        }

        public ServicE Add(ServicE newservice)
        {
           _context.Add(newservice);
            _context.SaveChanges(true);
            return newservice;
        }

        public ServicE Delete(int id)
        {
            var profiling = _context.Services.Find(id);
            if (profiling == null)
            {
                return null;
            }
            _context.Services.Remove(profiling);
            _context.SaveChanges();
            return profiling;
        }

        public List<ServicE> GetAll()
        {
            return _context.Services.ToList();
        }

        public ServicE Update(ServicE update, int id)
        {
           ServicE foundservice = GetById(id);
            if (foundservice == null)
            {
                return null;
            }
            foundservice.networkTypeId = update.networkTypeId;
            foundservice.Name = update.Name;
            foundservice.ownerBusinessId = update.ownerBusinessId;
            _context.Services.Update(foundservice);
            _context.SaveChanges(true);
            return foundservice;
        }

        public ServicE GetById(int id)
        {
            return _context.Services.Find(id);
        }
    }
}
