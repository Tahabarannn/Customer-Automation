using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class StatusManager : IStatusService
    {
        IStatusDal _StatusDal;

        public StatusManager(IStatusDal statusDal)
        {
            _StatusDal = statusDal;
        }
        public Status GetByID(int id)
        {
            return _StatusDal.Get(x => x.StatusID == id);
        }

        public List<Status> GetList()
        {
            return _StatusDal.List();
        }

        public void StatusAdd(Status status)
        {
            _StatusDal.Insert(status);
        }

        public void StatusDelete(Status status)
        {
            _StatusDal.Update(status);
        }

        public void StatusUpdate(Status status)
        {
            _StatusDal.Update(status);
        }
    }
}
