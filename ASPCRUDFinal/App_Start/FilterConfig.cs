using System.Web;
using System.Web.Mvc;

namespace ASPCRUDFinal
    // me sirve para configurar seguridad de autenticacion.
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
