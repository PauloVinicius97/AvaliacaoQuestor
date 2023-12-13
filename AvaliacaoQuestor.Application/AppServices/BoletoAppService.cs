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
            /*
             * Melhor fazer assim do que ter o Banco dentro no Boleto, pois imagine
             * que você está carregando vários boletos: 
             * teremos dados repetidos de Banco que não são necessários (um Banco por Boleto) e vão ocupar memória à toa.
             */
            var boletos = _boletoService.GetAll();
            var boletoViewModels = _mapper.Map<List<BoletoViewModel>>(boletos);

            var bancos = _bancoService.GetAll();

            return GetBoletoViewModelsWithInterestCalculated(boletoViewModels, bancos.ToList());
        }

        public BoletoViewModel GetByIdWithInterestPercentageCalculated(Guid id)
        {
            var boleto = _boletoService.GetById(id);
            var boletoViewModel = _mapper.Map<BoletoViewModel>(boleto);
            
            var boletoViewModels = new List<BoletoViewModel>();
            boletoViewModels.Add(boletoViewModel);

            var bancos = _bancoService.GetAll();

            boletoViewModels = GetBoletoViewModelsWithInterestCalculated(boletoViewModels, bancos.ToList()).ToList();

            return boletoViewModels.FirstOrDefault();
        }

        private IEnumerable<BoletoViewModel> GetBoletoViewModelsWithInterestCalculated(List<BoletoViewModel> boletoViewModels, List<Banco> bancos)
        {
            foreach (var boletoViewModel in boletoViewModels)
            {
                if (boletoViewModel.DueDate < DateTime.Today)
                {
                    var bancoFromBoleto = bancos.FirstOrDefault(b => b.Id == boletoViewModel.BancoId);
                    // Para pegar o número de dias corridos e não 12,4 dias, por exemplo, caso a data tenha sido cadastrada com horário
                    var daysBetweenDates = (int)Math.Ceiling((DateTime.Today - boletoViewModel.DueDate).TotalDays); 
                    var amountPlusInterest = CalculateInterestByDays(daysBetweenDates, boletoViewModel.Amount, bancoFromBoleto.InterestPercentage);

                    boletoViewModel.AmountToPayByInterestPercentage = amountPlusInterest;
                }
            }

            return boletoViewModels;
        }

        private decimal CalculateInterestByDays(int numberOfDays, decimal amount, float interestPercentage)
        {
            return amount + (amount * ((decimal)interestPercentage / 100)  * numberOfDays);
        }
    }
}
