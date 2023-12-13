using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace AvaliacaoQuestor.Application.ViewModels
{
    public class BoletoViewModel
    {
        public Guid Id { get; set; }
        public Guid BancoId { get; set; }
        public string? Name { get; set; }
        public string? CPF { get; set; }
        public decimal Amount { get; set; }
        public DateTime DueDate { get; set; }
        public string? Observation { get; set; }
        public decimal? AmountToPayByInterestPercentage { get; set; }
    }
}
