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
    public class IsFraudManager : IsFraudService
    {
        IsFraudDal _isFraudDal;

        public IsFraudManager(IsFraudDal isFraudDal)
        {
            _isFraudDal = isFraudDal;
        }

        public List<IsFraud> GetList()
        {
            return _isFraudDal.List();
        }
    }
}
