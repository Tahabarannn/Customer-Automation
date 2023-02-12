using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Quartz;
using System.Threading.Tasks;

namespace AffiliateAutomation.Tasks.Jobs
{
    public class AffiliateDateInfo : IJob
    {
        AffiliateManager af = new AffiliateManager(new EfAffiliateDal());

        Task IJob.Execute(IJobExecutionContext context)
        {
            try
            {
                GetInfo();
                return Task.CompletedTask;
            }

            catch
            {
                throw;
            }
        }

        void GetInfo()
        {
            var Affiliate = af.AdminGetAffiliateDate();
            foreach (var affiliate in Affiliate)
            {
                affiliate.PassedDay += 1;
                af.AffiliateUpdate(affiliate);
            }
        }

    }
}