using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IAffiliateService
    {
        List<Affiliate> GetListActive();
        List<Affiliate> GetListPassive();
        List<Affiliate> GetListFraud();
        List<Affiliate> GetPassedDate();
        List<Affiliate> GetListByAdminActive(int id);
        List<Affiliate> GetListByAdminPassive(int id);
        List<Affiliate> GetListByUserActive(int id);
        List<Affiliate> GetListByUserPassive(int id);
        List<Affiliate> AdminGetAffiliateDate();
        List<Affiliate> AdminGetPassedDate(int id);

        void AffiliateAdd(Affiliate affiliate);
        Affiliate GetByID(int id);
        void AffiliateUpdate(Affiliate affiliate);
        void AffiliateDelete(Affiliate affiliate);
    }
}
