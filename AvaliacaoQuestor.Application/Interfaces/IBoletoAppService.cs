using AvaliacaoQuestor.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvaliacaoQuestor.Application.Interfaces
{
    public interface IBoletoAppService
    {
        void Add(BoletoPostViewModel boletoPostViewModel);

        BoletoViewModel GetByIdWithInterestPercentageCalculated(Guid id);

        IEnumerable<BoletoViewModel> GetAllWithInterestPercentageCalculated();

        void Dispose();
    }
}
