using AutoMapper;
using AvaliacaoQuestor.Application.Interfaces;
using AvaliacaoQuestor.Application.ViewModels;
using AvaliacaoQuestor.Domain.Entities;
using AvaliacaoQuestor.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvaliacaoQuestor.Application.AppServices
{
    public class BoletoAppService : IBoletoAppService
    {
        private readonly IServiceBoleto _boletoService;
        private readonly IServiceBanco _bancoService;
        private readonly IMapper _mapper;

        public BoletoAppService(IServiceBoleto serviceBoleto, IServiceBanco serviceBanco, IMapper mapper)

        {
            _boletoService = serviceBoleto;
            _bancoService = serviceBanco;
            _mapper = mapper;
        }

        public void Add(BoletoPostViewModel boletoPostViewModel)
        {
            var boleto = _mapper.Map<Boleto>(boletoPostViewModel);
            _boletoService.Add(boleto);
        }

        public void Dispose()
        {
            _boletoService.Dispose();
        }

        public IEnumerable<BoletoViewModel> GetAllWithInterestPercentageCalculated()
        {
            var boletos = _boletoService.GetAll();
            var boletoViewModels = _mapper.Map<List<BoletoViewModel>>(boletos);

            var bancos = _boletoService.GetAll();
            var 

            return boletoViewModels;
        }

        public BoletoViewModel GetById(Guid id)
        {
            var boleto = _boletoService.GetById(id);
            return _mapper.Map<BoletoViewModel>(boleto);
        }
    }
}
