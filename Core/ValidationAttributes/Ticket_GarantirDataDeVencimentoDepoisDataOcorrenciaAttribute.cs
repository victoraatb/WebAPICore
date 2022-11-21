using Core.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.ValidationAttributes
{
    internal class Ticket_GarantirDataDeVencimentoDepoisDataOcorrenciaAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var ticket = validationContext.ObjectInstance as Ticket;
            if (ticket != null && !ticket.ValidarDataVencimentoDepoisDataCriacao())
                return new ValidationResult("A data de vencimento deve ser maior que a data da ocorrência.");

            return ValidationResult.Success;

        }
    }
}
