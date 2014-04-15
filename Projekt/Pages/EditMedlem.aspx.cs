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
    public partial class EditMedlem : System.Web.UI.Page
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

        public Projekt.Model.Medlem EditMedlemFormView_GetItem([RouteData] int id)
        {
            try
            {
                return Service.GetMedlem(id);
            }
            catch (Exception)
            {
                ModelState.AddModelError(String.Empty, "Ett fel inträffade vid hämtningen av medlemmen.");
                return null;
            }
        }

        public void EditMedlemFormView_UpdateItem(int Medid)
        {
            try
            {
                var medlem = Service.GetMedlem(Medid);
                if (medlem == null)
                {
                    ModelState.AddModelError(string.Empty,
                    string.Format("Medlemen med id:t {0} hittades inte.", Medid));
                    return;
                }

                if (TryUpdateModel(medlem))
                {
                    Service.SaveMedlem(medlem);
                    Message = string.Format("Medlemmen ha redigerats!");
                    Response.RedirectToRoute("MedlemDetails", new { id = medlem.Medid });
                    Context.ApplicationInstance.CompleteRequest();
                }
            }
            catch (Exception)
            {
                ModelState.AddModelError(string.Empty, "Ett fel inträffade då medlemmen skulle uppdateras.");
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
                ModelState.AddModelError(String.Empty, "Fel inträffade då band namnet skulle hämtades ut.");
                return null;
            }
        }
        }
    }
