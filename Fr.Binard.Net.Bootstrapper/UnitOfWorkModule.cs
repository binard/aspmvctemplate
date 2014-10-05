using Fr.Binard.Net.Domain;
using Fr.Binard.Net.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Fr.Binard.Net.Bootstrapper
{
    public class UnitOfWorkModule : IHttpModule
    {

        public void Init(HttpApplication context)
        {
            context.BeginRequest += context_BeginRequest;
            context.EndRequest += context_EndRequest;
        }


        private void context_BeginRequest(object sender, EventArgs e)
        {
            UnitOfWorkFactory.GetDefault().Begin();
        }

        private void context_EndRequest(object sender, EventArgs e)
        {
            IUnitOfWork uof = UnitOfWorkFactory.GetDefault();
            try
            {
                uof.Commit();
            }
            catch
            {
                uof.Rollback();
            }
            finally
            {
                uof.Dispose();
            }
        }

        public void Dispose()
        {
            
        }
    }
}
