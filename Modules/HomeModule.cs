using System;
using System.Collections.Generic;
using Nancy;
using Nancy.ViewEngines.Razor;


namespace HairSalon
{

    public class HomeModule : NancyModule
    {
      public HomeModule()
      {
        Get["/"] = _ =>
        {
          return View["index.cshtml"];
        };

        Get["/stylists"] = _ =>
        {
          return View["Stylists.cshtml", ModelMaker()];
        };

        Post["/stylists"] = _ =>
        {
          Stylist newStylist = new Stylist(Request.Form["stylist"]);
          newStylist.Save();
          return View["Stylists.cshtml", ModelMaker()];
        };

        Get["/stylists/{id}"]= parameters =>
        {
          Stylist newStylist = Stylist.Find(parameters.id);
          Dictionary<string, object> model = ModelMaker();
          model.Add("Stylist Object", newStylist);
          model.Add("Client List", Client.GetByStylist(newStylist.GetId()));
          return View ["stylist.cshtml", model];

        };

        Get["/clients"] = _ =>
        {
          return View ["clients.cshtml", ModelMaker()];
        };

        Post["/clients"] = _ =>
        {
          Client newClient = new Client(Request.Form["client"], Request.Form["id_c"]);
          newClient.Save();
          return View["clients.cshtml", ModelMaker()];
        };

      }

      public static Dictionary<string, object> ModelMaker()
      {
        Dictionary<string, object> model = new Dictionary<string, object>{};
        model.Add("Stylists", Stylist.GetAll());
        model.Add("Clients", Client.GetAll());
        return model;
      }


    }
}
