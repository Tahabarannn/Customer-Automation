using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    internal interface ISocialService
    {
        List<SocialMedia> GetList();
        void SocialAdd(SocialMedia socialmedia);
        SocialMedia GetByID(int id);
        void SocialUpdate(SocialMedia socialmedia);
        void SocialDelete(SocialMedia socialmedia);
    }
}
