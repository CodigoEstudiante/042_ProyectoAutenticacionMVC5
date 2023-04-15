using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using testautenticacion.Models;

namespace testautenticacion.Permisos
{
    public class PermisosRolAttribute : ActionFilterAttribute
    {
        private Rol idrol;


        public PermisosRolAttribute(Rol _idrol) {

            idrol = _idrol;
        }



        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (HttpContext.Current.Session["Usuario"] != null) {

                Usuarios usuario = HttpContext.Current.Session["Usuario"] as Usuarios;


                if (usuario.IdRol != this.idrol) {

                    filterContext.Result = new RedirectResult("~/Home/SinPermiso");
                
                }


            }



            base.OnActionExecuting(filterContext);
        }



    }
}