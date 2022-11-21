using Core.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.ValidationAttributes
{
    internal class Ticket_GarantirDataDeVencimentoMaiorHojeAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var ticket = validationContext.ObjectInstance as Ticket;
            if (ticket != null && !ticket.ValidarDataVencimentoNoFuturo())
                return new ValidationResult("A data de vencimento deve estar no futuro.");

            return ValidationResult.Success;

        }
    }
}
