using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IFormService
    {
        List<Form> GetList();
        List<Form> GetListSA();
        List<Form> GetListSAPassive();
        List<Form> GetListSASpam();
        List<Form> GetListAdmin(int id);
        List<Form> GetListAdminPassive(int id);
        List<Form> GetListAdminSpam(int id);
        List<Form> GetStatusForm(string p);
        List<Form> GetFormByUser(int id);
        List<Form> GetPassiveFormByUser(int id);
        List<Form> GetSpamFormByUser(int id);
        void FormAdd(Form form);
        void FormDelete(Form form);
        Form GetByID(int id);
        void FormUpdate(Form form);
    }
}
