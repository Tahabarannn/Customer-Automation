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
    public class FormStatusManager : IFormStatusService
    {
        IFormStatusDal _formStatusDal;

        public FormStatusManager(IFormStatusDal formStatusDal)
        {
            _formStatusDal = formStatusDal;
        }   

        public List<FormStatus> GetList()
        {
            return _formStatusDal.List();
        }
    }
}
