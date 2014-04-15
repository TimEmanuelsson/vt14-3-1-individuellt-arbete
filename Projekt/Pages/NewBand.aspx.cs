using Projekt.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Projekt.Pages
{
    public partial class NewBand : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        private string Message
        {
            get
            {
                return Session["Message"] as string;
            }
            set
            {
                Session["Message"] = value;
            }
        }

        public void NewBandFormView_InsertItem(Model.Band band)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Service service = new Service();
                    service.SaveBand(band);
                    Message = string.Format("Nytt band ha lagts till!");
                    Response.RedirectToRoute("BandDetails", new { id = band.Bandid });
                    Context.ApplicationInstance.CompleteRequest();
                }
                catch(Exception)
                {
                    ModelState.AddModelError(string.Empty, "Ett fel inträffade när du försökte lägga till ett nytt band.");
                }
            }
        }
    }
}