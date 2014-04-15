using Projekt.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Projekt.Pages
{
    public partial class Huvudroll : System.Web.UI.Page
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

        public IEnumerable<Projekt.Model.Huvudroll> ListViewHuvudroll_GetData()
        {
            try
            {
                return Service.GetHuvudroller();
            }
            catch (Exception)
            {
                ModelState.AddModelError(String.Empty, "Ett fel inträffade när huvudrollerna skulle hämtas.");
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