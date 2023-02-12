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
    public class IsActiveManager : IsActiveService
    {
        IsActiveDal _isActiveDal;

        public IsActiveManager(IsActiveDal isActiveDal)
        {
            _isActiveDal = isActiveDal;
        }

        public List<IsActive> GetList()
        {
            return _isActiveDal.List();
        }
    }
}
