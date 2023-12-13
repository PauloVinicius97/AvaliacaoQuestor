using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvaliacaoQuestor.Domain.Entities
{
    public class Boleto
    {
        public Guid Id { get; private set; }
        public Guid BancoId { get; private set; }
        public string? Name { get; private set; }
        public string? CPF { get; private set; }
        public decimal Amount { get; private set; }
        public DateTime DueDate { get; private set; }
        public string? Observation { get; private set; }

        private Boleto() { }

        public Boleto(string name, string cpf, decimal amount, DateTime dueDate, string observation)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            CPF = cpf ?? throw new ArgumentNullException(nameof(cpf));
            Amount = amount > 0 ? amount : throw new ArgumentException("Valor deve ser maior que zero", nameof(amount));
            DueDate = dueDate;
            Observation = observation;
        }
    }
}
