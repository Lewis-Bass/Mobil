using Mobil.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mobil.Services
{
    public class BinderService
    {

        #region constructor

        public BinderService()
        {

        }

        #endregion

        public async Task< List<Binder>> SearchBinders(string searchBinderName)
        {
            searchBinderName = searchBinderName.Trim().ToLowerInvariant();
            // TODO: Connect to the ark and get the list
            var retval = new List<Binder>
            {
                new Binder{ BinderID="1", BinderName="Binder 1" },
                new Binder{ BinderID="2", BinderName="Binder 2" },
                new Binder{ BinderID="3", BinderName="Binder 3" },
                new Binder{ BinderID="4", BinderName="Binder 4" },
                new Binder{ BinderID="5", BinderName="Binder 5" },
                new Binder{ BinderID="6", BinderName="Binder 6" },
                new Binder{ BinderID="7", BinderName="Binder 7" },
                new Binder{ BinderID="8", BinderName="Binder 8" },
                new Binder{ BinderID="9", BinderName="Binder 9" },
                new Binder{ BinderID="10", BinderName="Binder 10" },
            };

            //return retval.Where(r=> r.BinderName.Contains(searchBinderName, StringComparison.InvariantCultureIgnoreCase)).ToList();
            return retval.Where(r => r.BinderName.ToLowerInvariant().Contains(searchBinderName)).ToList();
        }
    }
}
