using Core.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.ValidationAttributes
{
    public class Ticket_GarantirProjetoExisteAoInserirAttribute : ValidationAttribute
    {
        public Ticket_GarantirProjetoExisteAoInserirAttribute()
        {

        }
        
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            
            var request = validationContext.ObjectInstance as Ticket;
                       
            if (request != null && !request.ValidarDataReportadaPresente())
                return new ValidationResult("A data da ocorrência é requerida.");


            return ValidationResult.Success;

        }
    }
}
