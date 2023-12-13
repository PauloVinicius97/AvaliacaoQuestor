using AvaliacaoQuestor.Domain.Entities;
using AvaliacaoQuestor.Domain.Interfaces.Repositories;
using AvaliacaoQuestor.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvaliacaoQuestor.Domain.Services
{
    public class ServiceBoleto : ServiceBase<Boleto>, IServiceBoleto
    {
        public readonly IRepositoryBoleto _repositoryBoleto;

        public ServiceBoleto(IRepositoryBoleto repositoryBoleto) : base(repositoryBoleto)
        {
            _repositoryBoleto = repositoryBoleto;
        }
    }
}
