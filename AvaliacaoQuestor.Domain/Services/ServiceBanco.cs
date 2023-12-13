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
    public class ServiceBanco : ServiceBase<Banco>, IServiceBanco
    {
        public readonly IRepositoryBanco _repositoryBanco;

        public ServiceBanco(IRepositoryBanco repositoryBanco) : base(repositoryBanco)
        {
            _repositoryBanco = repositoryBanco;
        }
    }
}
