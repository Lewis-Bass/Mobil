using System;
using System.Collections.Generic;
using System.Text;

namespace Mobil.Models
{
    public class Binder
    {
        /// <summary>
        /// ark identifier for the binder
        /// </summary>
        public string BinderID { get; set; }

        /// <summary>
        /// ark name for the binder
        /// </summary>
        public string BinderName { get; set; }

        ///////////////// <summary>
        ///////////////// Has this entry been selected to be processed?
        ///////////////// </summary>
        //////////////public bool IsSelected { get; set; }
    }
}
