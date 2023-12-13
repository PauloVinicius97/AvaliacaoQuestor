namespace AvaliacaoQuestor.Domain.Entities
{
    public class Banco
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public string Code { get; private set; }
        public float InterestPercentage { get; private set; }

        public Banco(string name, string code, float interestPercentage)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Code = code ?? throw new ArgumentNullException(nameof(code));
            InterestPercentage = interestPercentage > 0 ? interestPercentage
                : throw new ArgumentException("Percentual de juros deve ser maior que zero", nameof(interestPercentage));
        }
    }
}


