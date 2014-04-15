using Projekt.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Projekt.Pages
{
    public partial class DeleteBand : System.Web.UI.Page
    {

        private Service _service;

        private Service Service
        {
            get { return _service ?? (_service = new Service()); }
        }

        protected int Id
        {
            get { return int.Parse(RouteData.Values["id"].ToString()); }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            Avbryt.NavigateUrl = GetRouteUrl("BandDetails", new { id = Id });

            if (!IsPostBack)
            {
                try
                {
                    var band = Service.GetBand(Id);
                    if (band != null)
                    {
                        return;
                    }
                    ModelState.AddModelError(String.Empty, String.Format("Bandet med bandnamnet {0} hittades inte!", Id));
                }
                catch (Exception)
                {
                    ModelState.AddModelError(String.Empty, "Fel inträffade då bandet hämtades inför borttagning.");
                }
            }
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

        protected void Tabortband_Command(object sender, CommandEventArgs e)
        {
            try
            {
                var id = int.Parse(e.CommandArgument.ToString());
                Service.DeleteBand(id);
                Message = string.Format("Bandet ha tagits bort!");
                Response.RedirectToRoute("Band", null);
                Context.ApplicationInstance.CompleteRequest();
            }
            catch (Exception)
            {
                ModelState.AddModelError(string.Empty, "Ett fel inträffade då du försökte ta bort bandet");
            }
        }
    }
}