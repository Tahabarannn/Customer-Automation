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
    public class SocialManager : ISocialService
    {
        ISocialMediaDal _socialMediaDal;

        public SocialManager(ISocialMediaDal socialMediaDal)
        {
            _socialMediaDal = socialMediaDal;
        }

        public SocialMedia GetByID(int id)
        {
            return _socialMediaDal.Get(x => x.SocialMediaID == id);
        }

        public List<SocialMedia> GetList()
        {
            return _socialMediaDal.List();
        }

        public void SocialAdd(SocialMedia socialmedia)
        {
            _socialMediaDal.Insert(socialmedia);
        }

        public void SocialUpdate(SocialMedia socialmedia)
        {
            _socialMediaDal.Update(socialmedia);
        }
        public void SocialDelete(SocialMedia socialmedia)
        {
            _socialMediaDal.Update(socialmedia);
        }
    }
}
