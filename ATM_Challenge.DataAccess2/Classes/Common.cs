using ATM_Challenge.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace ATM_Challenge.DataAccess.Classes
{
    internal class Common
    {
        public static DTO.ModelATMContainer DataContext
        {
            get
            { 
                if (HttpContext.Current.Items["DataContext"] == null)
                {
                    HttpContext.Current.Items["DataContext"] = new DTO.ModelATMContainer();
                }
                return (DTO.ModelATMContainer)HttpContext.Current.Items["DataContext"];
            }
        }
    }
}
