using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebQLNS_VTH.Controllers
{
    public class ManageController : Controller
    {
        [HttpGet]
        // GET: Manage
        public string tuSinhMa(string tuSinhMa)
        {
            string pTrc = tuSinhMa.Substring(0,2);
            string pSau = "";
            int n = int.Parse(tuSinhMa.Substring(2,2)) + 1;
            if(n > 9 )
            {
                pSau = n.ToString();
            }
            else
            {
                pSau = "0"+n.ToString();
            }
            return pTrc + pSau;
        }
    }
}