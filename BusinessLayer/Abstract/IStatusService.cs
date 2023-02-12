using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IStatusService
    {
        List<Status> GetList();
        void StatusAdd(Status status);
        Status GetByID(int id);
        void StatusUpdate(Status status);
        void StatusDelete(Status status);
    }
}
