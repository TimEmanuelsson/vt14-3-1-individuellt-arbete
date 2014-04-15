using Projekt.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Projekt.Pages
{
    public partial class EditBand : System.Web.UI.Page
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

        public Projekt.Model.Band EditBandFormView_GetItem([RouteData]int id)
        {
            try
            {
                return Service.GetBand(id);
            }
            catch (Exception)
            {
                ModelState.AddModelError(String.Empty, "Ett fel inträffade då bandet skulle hämtas.");
                return null;
            }
        }

        public void EditBandFormView_UpdateItem(int Bandid)
        {
            try
            {
                var band = Service.GetBand(Bandid);
                if (band == null)
                {
                    ModelState.AddModelError(string.Empty,
                        string.Format("Bandet med id:t {0} hittades inte.", Bandid));
                    return;
                }

                if (TryUpdateModel(band))
                {
                    Service.SaveBand(band);
                    Message = string.Format("Bandet ha redigerats!");
                    Response.RedirectToRoute("BandDetails", new { id = band.Bandid });
                    Context.ApplicationInstance.CompleteRequest();
                }
            }
            catch (Exception)
            {
                ModelState.AddModelError(string.Empty, "Ett fel inträffade då bandet skulle uppdateras.");
            }
        }
    }
}