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
    public class AffiliateManager : IAffiliateService
    {

        IAffiliateDal _affiliateDal;

        public AffiliateManager(IAffiliateDal affiliateDal)
        {
            _affiliateDal = affiliateDal;
        }

        /////////////////////////SUPER ADMIN///////////////////////////////////////
        public void AffiliateAdd(Affiliate affiliate)
        {
            _affiliateDal.Insert(affiliate);
        }

        public void AffiliateUpdate(Affiliate affiliate)
        {
            _affiliateDal.Update(affiliate);
        }

        public Affiliate GetByID(int id)
        {
            return _affiliateDal.Get(x => x.AffID == id);
        }

        public void AffiliateDelete(Affiliate affiliate)
        {
            _affiliateDal.Update(affiliate);
        }

        public List<Affiliate> GetListActive()
        {
            return _affiliateDal.List(x => x.IsActive.Active == "Aktif" && x.IsFraud.Fraud == "Hayır");
        }

        public List<Affiliate> GetListPassive()
        {
            return _affiliateDal.List(x => x.IsActive.Active == "Pasif" && x.IsFraud.Fraud == "Hayır");
        }
        public List<Affiliate> GetListFraud()
        {
            return _affiliateDal.List(x => x.IsFraud.Fraud == "Evet" && x.IsActive.Active == "Pasif");
        }

        public List<Affiliate> AdminGetAffiliateDate()
        {
            return _affiliateDal.List(x => x.IsActiveID == 1 && DateTime.Now >= x.EndDate);
        }

        public List<Affiliate> GetPassedDate()
        {
            return _affiliateDal.List(x => x.IsActiveID == 1 && x.PassedDay != null);
        }

        /////////////////////////ADMIN SECTION///////////////////////////////////////

        public List<Affiliate> GetListByAdminActive(int id)
        {
            return _affiliateDal.List(x => x.User.AdminID == id && x.IsActive.Active == "Aktif" && x.IsFraud.Fraud == "Hayır");
        }

        public List<Affiliate> GetListByAdminPassive(int id)
        {
            return _affiliateDal.List(x => x.User.AdminID == id && x.IsActive.Active == "Pasif" && x.IsFraud.Fraud == "Hayır");
        }

        public List<Affiliate> AdminGetPassedDate(int id)
        {
            return _affiliateDal.List(x => x.User.AdminID == id && x.IsActiveID == 1 && x.PassedDay != null);
        }

        /////////////////////////USER SECTION///////////////////////////////////////

        public List<Affiliate> GetListByUserActive(int id)
        {
            return _affiliateDal.List(x => x.User.UserID == id && x.IsActive.Active == "Aktif" && x.IsFraud.Fraud == "Hayır");
        }

        public List<Affiliate> GetListByUserPassive(int id)
        {
            return _affiliateDal.List(x => x.User.UserID == id && x.IsActive.Active == "Pasif" && x.IsFraud.Fraud == "Hayır");
        }

    }
}
