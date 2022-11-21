using Core.ValidationAttributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    public class Ticket
    {
        public int? TicketId { get; set; }

        [Required]
        public int? ProjectId { get; set; }
        
        [StringLength(100)]
        public string Titulo { get; set; } = string.Empty;
        public string Descricao { get; set; } = string.Empty;
        [StringLength(50)]
        public string Dono { get; set; } = string.Empty;

        [Ticket_GarantirDataDeVencimentoMaiorHoje]
        [Ticket_GarantirDataDeVencimentoExiste]
        [Ticket_GarantirDataDeVencimentoDepoisDataOcorrencia]
        public DateTime? DataVencimento { get; set; }

        [Ticket_GarantirDataOcorrenciaExiste]
        public DateTime? DataOcorrencia { get; set; }

        public Project? Project { get; set; }

        public bool ValidarDescricao()
        {
            return !string.IsNullOrWhiteSpace(Descricao);
        }


        /// <summary>
        /// Quando criar um ticket se a data de vencimento for inserida deve estar no futuro
        /// </summary>        
        public bool ValidarDataVencimentoNoFuturo()
        {
            if (TicketId.HasValue) return true;
            if (!DataVencimento.HasValue) return true;

            return (DataVencimento.Value > DateTime.Now);
        }
        /// <summary>
        /// Quando existir criador do ticket, a data de criação deve estar presente
        /// </summary>     
        public bool ValidarDataReportadaPresente()
        {
            if (string.IsNullOrWhiteSpace(Dono)) return true;
            return DataOcorrencia.HasValue;
        }
        /// <summary>
        /// Quando houver criador do ticket, a data de vencimento deve estar presente
        /// </summary>        
        public bool ValidarDataVencimentoPresente()
        {
            if (string.IsNullOrWhiteSpace(Dono)) return true;
            return DataVencimento.HasValue;
        }
        /// <summary>
        /// Quando data de Vencimento existir ela precisa ser depois da data de criação do ticket
        /// </summary>
        public bool ValidarDataVencimentoDepoisDataCriacao()
        {
            if (!DataVencimento.HasValue || !DataOcorrencia.HasValue) return true;

            return DataVencimento.Value.Date >= DataOcorrencia.Value.Date;
        }

    }
}
