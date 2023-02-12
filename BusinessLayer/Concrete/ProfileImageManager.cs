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
    public class ProfileImageManager : IProfileImageService
    {
        IProfileImageDal _profileImageDal;

        public ProfileImageManager(IProfileImageDal profileImageDal)
        {
            _profileImageDal = profileImageDal;
        }
        public List<ProfileImage> GetList()
        {
            return _profileImageDal.List();
        }
    }
}
