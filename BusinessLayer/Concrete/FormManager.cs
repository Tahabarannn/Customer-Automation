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
    public class FormManager : IFormService
    {
        IFormDal _FormDal;

        public FormManager(IFormDal formDal)
        {
            _FormDal = formDal;
        }

        public void FormAdd(Form form)
        {
            _FormDal.Insert(form);
        }

        public void FormDelete(Form form)
        {
            _FormDal.Update(form);
        }

        public void FormUpdate(Form form)
        {
            _FormDal.Update(form);
        }

        public Form GetByID(int id)
        {
            return _FormDal.Get(x => x.FormID == id);
        }

        public List<Form> GetListSA()
        {
            return _FormDal.List(x => x.AdminID == null && x.IsActiveID == 1);
        }

        public List<Form> GetListSAPassive()
        {
            return _FormDal.List(x => x.AdminID != null && x.IsActiveID == 1);
        }

        public List<Form> GetListSASpam()
        {
            return _FormDal.List(x => x.IsActiveID == 2);
        }
        public List<Form> GetStatusForm(string p)
        {
            return _FormDal.List(x => x.AffMail.Contains(p));
        }
        public List<Form> GetList()
        {
            return _FormDal.List();
        }

        public List<Form> GetUnread()
        {
            return _FormDal.List(x => x.AdminID == null);
        }

        ////////Admin///////////////
        public List<Form> GetListAdmin(int id)
        {
            return _FormDal.List(x => x.AdminID == id && x.IsActiveID == 1 && x.UserID == null);
        }

        public List<Form> GetListAdminPassive(int id)
        {
            return _FormDal.List(x => x.AdminID == id && x.UserID != null && x.IsActiveID == 1);
        }

        public List<Form> GetListAdminSpam(int id)
        {
            return _FormDal.List(x => x.AdminID == id && x.IsActiveID == 2);
        }

        ////////User///////////////

        public List<Form> GetFormByUser(int id)
        {
            return _FormDal.List(x => x.UserID == id && x.IsActiveID == 1 && x.FormStatusID == 1);
        }

        public List<Form> GetPassiveFormByUser(int id)
        {
            return _FormDal.List(x => x.UserID == id && x.IsActiveID == 1 && x.FormStatusID != 1 );
        }

        public List<Form> GetSpamFormByUser(int id)
        {
            return _FormDal.List(x => x.UserID == id && x.IsActiveID == 2);
        }
    }
}
