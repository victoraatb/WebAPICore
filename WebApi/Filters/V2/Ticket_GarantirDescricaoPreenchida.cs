using Core.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace WebAPI.Filters.V2
{
    public class Ticket_GarantirDescricaoPreenchidaAttribute: ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);

            var ticket = context.ActionArguments["ticket"] as Ticket;
            if (ticket != null && !ticket.ValidarDescricao())
            {
                context.ModelState.AddModelError("Descricao","Descrição é necessária");
                context.Result = new BadRequestObjectResult(context.ModelState);
            }
        }
    }
}