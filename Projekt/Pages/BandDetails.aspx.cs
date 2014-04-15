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
    public partial class BandDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (ifmessage)
            {
                Status.Text = Message;
                Status.Visible = true;
                Remover.Visible = true;
            }
        }

        private bool ifmessage
        {
            get
            {
                return Session["Message"] != null;
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

        public Projekt.Model.Band BandDetailsFormView_GetItem([RouteData] int id)
        {
            try
            {
                Service service = new Service();
                return service.GetBand(id);
            }
            catch (Exception)
            {
                ModelState.AddModelError(String.Empty, "Ett fel inträffade när bandet skulle hämtas.");
                return null;
            }
        }

        protected void Remover_Click(object sender, EventArgs e)
        {
            Session.Remove("Message");
            Status.Visible = false;
            Remover.Visible = false;
        }

    }
}