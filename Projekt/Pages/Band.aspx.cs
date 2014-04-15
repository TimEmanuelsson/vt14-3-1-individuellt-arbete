using Projekt.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Projekt.Pages
{
    public partial class Band : System.Web.UI.Page
    {

        private Service _service;

        private Service Service
        {
            get { return _service ?? (_service = new Service()); }
        }

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

        public IEnumerable<Projekt.Model.Band> ListViewBand_GetData()
        {
            try
            {
                return Service.GetBands();
            }
            catch (Exception)
            {
                ModelState.AddModelError(String.Empty, "Fel inträffade när du banden skulle hämtas ut.");
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