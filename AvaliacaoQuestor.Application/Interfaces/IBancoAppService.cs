using AvaliacaoQuestor.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvaliacaoQuestor.Application.Interfaces
{
    public interface IBancoAppService
    {
        void Add(BancoPostViewModel bancoPostViewModel);

        BancoViewModel GetById(Guid id);

        IEnumerable<BancoViewModel> GetAll();

        void Dispose();
    }
}
