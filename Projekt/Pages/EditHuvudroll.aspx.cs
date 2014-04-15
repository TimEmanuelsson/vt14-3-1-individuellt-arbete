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
    public partial class EditHuvudroll : System.Web.UI.Page
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

        public Projekt.Model.Huvudroll EditHuvudrollFormView_GetItem([RouteData]int id)
        {
            try
            {
                return Service.GetHuvudroll(id);
            }
            catch (Exception)
            {
                ModelState.AddModelError(String.Empty, "Ett fel inträffade då bandet skulle hämtas.");
                return null;
            }
        }

        public void EditHuvudrollFormView_UpdateItem(int Rollid)
        {
            try
            {
                var huvudroll = Service.GetHuvudroll(Rollid);
                if (huvudroll == null)
                {
                    ModelState.AddModelError(string.Empty,
                        string.Format("Huvudrollen med id:t {0} hittades inte.", Rollid));
                    return;
                }

                if (TryUpdateModel(huvudroll))
                {
                    Service.SaveHuvudroll(huvudroll);
                    Message = string.Format("Huvudrollen ha redigerats!");
                    Response.RedirectToRoute("Huvudroll", null);
                    Context.ApplicationInstance.CompleteRequest();
                }
            }
            catch (Exception)
            {
                ModelState.AddModelError(string.Empty, "Ett fel inträffade då Huvudrollen skulle uppdateras.");
            }
        }
    }
}