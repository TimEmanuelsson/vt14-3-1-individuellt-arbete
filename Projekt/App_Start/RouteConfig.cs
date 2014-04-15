using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;

namespace Projekt.App_Start
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            #region Länkar

            routes.MapPageRoute("Default", "", "~/Pages/Medlemmar.aspx");
            routes.MapPageRoute("NewBand", "Band/ny1", "~/Pages/NewBand.aspx");
            routes.MapPageRoute("NewMedlem", "Medlem/Ny", "~/Pages/NewMedlem.aspx");
            routes.MapPageRoute("Medlemmar", "Medlemmar", "~/Pages/Medlemmar.aspx");
            routes.MapPageRoute("Band", "Band", "~/Pages/Band.aspx");
            routes.MapPageRoute("BandDetails", "Band/{id}", "~/Pages/BandDetails.aspx");
            routes.MapPageRoute("EditBand", "Band/{id}/Redigera", "~/Pages/EditBand.aspx");
            routes.MapPageRoute("MedlemDetails", "Medlem/{id}", "~/Pages/MedlemDetails.aspx");
            routes.MapPageRoute("EditMedlem", "Medlem/{id}/Redigera", "~/Pages/EditMedlem.aspx");
            routes.MapPageRoute("DeleteMedlem", "Medlem/{id}/Tabort", "~/Pages/DeleteMedlem.aspx");
            routes.MapPageRoute("DeleteBand", "Band/{id}/Tabort", "~/Pages/DeleteBand.aspx");
            routes.MapPageRoute("Huvudroll", "Huvudroller", "~/Pages/Huvudroll.aspx");
            routes.MapPageRoute("EditHuvudroll", "Huvudroller/{id}/Redigera", "~/Pages/EditHuvudroll.aspx");

            #endregion
        }
    }
}