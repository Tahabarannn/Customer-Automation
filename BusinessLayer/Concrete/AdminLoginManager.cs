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
    public class AdminLoginManager : IAdminLoginService
    {
        IAdminDal _adminDal;

        public AdminLoginManager(IAdminDal adminDal)
        {
            _adminDal = adminDal;
        }

        public Admin GetAdmin(string Adminusername, string Adminpassword, string userip)
        {
            return _adminDal.Get(x => x.AdminUserName == Adminusername && x.AdminPassword == Adminpassword && x.ServerIp == userip && x.IsActiveID == 1);
        }
    }
}
