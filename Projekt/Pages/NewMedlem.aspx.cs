using Projekt.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Projekt.Pages
{
    public partial class NewMedlem : System.Web.UI.Page
    {
        private Service _service;

        private Service Service
        {
            get { return _service ?? (_service = new Service()); }
        }

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
        public void NewMedlemFormView_InsertItem(Medlem medlem)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Service.SaveMedlem(medlem);
                    Message = string.Format("Ny medlem ha lagts till!");
                    Response.RedirectToRoute("MedlemDetails", new { id = medlem.Medid });
                    Context.ApplicationInstance.CompleteRequest();
                }
                catch(Exception)
                {
                    ModelState.AddModelError(string.Empty, "Ett fel inträffade när du försökte lägga till en ny medlem.");
                }
            }
        }
        public IEnumerable<Projekt.Model.Huvudroll> DropDownListRoll_GetData()
        {
            try
            {
                return Service.GetHuvudroller();
            }
            catch (Exception)
            {
                ModelState.AddModelError(String.Empty, "Fel inträffade då huvudrollerna skulle hämtades ut.");
                return null;
            }
        }

        public IEnumerable<Projekt.Model.Band> DropDownListband_GetData(Model.Band band)
        {
            try
            {
               return Service.GetBands();
            }
            catch (Exception)
            {
                ModelState.AddModelError(String.Empty, "Fel inträffade då banden skulle hämtas ut.");
                return null;
            }
        }
    }
}