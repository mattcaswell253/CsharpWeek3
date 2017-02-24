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
          return View["clients.cshtml", ModelMaker()];
        }
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
