using AvaliacaoQuestor.Domain.Entities;
using AvaliacaoQuestor.Domain.Interfaces.Repositories;
using AvaliacaoQuestor.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvaliacaoQuestor.Infra.Data.Repositories
{
    public class RepositoryBanco : RepositoryBase<Banco>, IRepositoryBanco
    {
        private readonly AvaliacaoQuestorContext _context;

        public RepositoryBanco(AvaliacaoQuestorContext context) : base(context)
        {
            _context = context;
        }
    }
}
