using AutoMapper;
using AvaliacaoQuestor.Application.Interfaces;
using AvaliacaoQuestor.Application.ViewModels;
using AvaliacaoQuestor.Domain.Entities;
using AvaliacaoQuestor.Domain.Interfaces.Services;
using AvaliacaoQuestor.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvaliacaoQuestor.Application.AppServices
{
    public class BancoAppService : IBancoAppService
    {
        private readonly IServiceBanco _bancoService;
        private readonly IMapper _mapper;

        public BancoAppService(IServiceBanco serviceBanco, IMapper mapper)

        {
            _bancoService = serviceBanco;
            _mapper = mapper;
        }

        public void Add(BancoPostViewModel bancoPostViewModel)
        {
            var banco = _mapper.Map<Banco>(bancoPostViewModel);
            _bancoService.Add(banco);
        }

        public void Dispose()
        {
            _bancoService.Dispose();
        }

        public IEnumerable<BancoViewModel> GetAll()
        {
            var bancos = _bancoService.GetAll();
            return _mapper.Map<List<BancoViewModel>>(bancos);
        }

        public BancoViewModel GetById(Guid id)
        {
            var banco = _bancoService.GetById(id);
            return _mapper.Map<BancoViewModel>(banco);
        }
    }
}
