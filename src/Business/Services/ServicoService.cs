using Business.Interfaces;
using Business.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services
{

    public class ServicoService
    {
        private readonly IServicoRepository _servico;

        public ServicoService(IServicoRepository servico)
        {
            _servico = servico;
        }

        public Task<List<Servico>> BuscarPorData(DateTime? minDate, DateTime? maxDate)
        {
           return _servico.BuscarPorData(minDate, maxDate);
        }
    }
}
