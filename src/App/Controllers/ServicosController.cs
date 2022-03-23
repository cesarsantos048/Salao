using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using App.ViewModels;
using Business.Interfaces;
using AutoMapper;
using Business.Models;

namespace App.Controllers
{
    public class ServicosController : BaseController
    {
        private readonly IServicoRepository _servicoRepository;
        private readonly IClienteRepository _clienteRepository;
        private readonly IMapper _mapper;

        public ServicosController(IServicoRepository servicoRepository,
                                  IClienteRepository clienteRepository,
                                  IMapper mapper)
        {
            _servicoRepository = servicoRepository;
            _clienteRepository = clienteRepository;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            return View(_mapper.Map<IEnumerable<ServicoViewModel>>(await _servicoRepository.ObterServicosClientes()));
        }

        public async Task<IActionResult> Details(Guid id)
        {
            var servicoViewModel = await ObterServico(id);
            if (servicoViewModel == null) return NotFound();

            return View(servicoViewModel);
        }

        public async Task<IActionResult> Create()
        {
            var servicoViewModel = await PopularClientes(new ServicoViewModel());

            return View(servicoViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ServicoViewModel servicoViewModel)
        {
            servicoViewModel = await PopularClientes(servicoViewModel);

            if (!ModelState.IsValid) return View(servicoViewModel);

            await _servicoRepository.Adicionar(_mapper.Map<Servico>(servicoViewModel));

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Edit(Guid id)
        {
            var servicoViewModel = await ObterServico(id);
            if (servicoViewModel == null) return NotFound();
            
            return View(servicoViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, ServicoViewModel servicoViewModel)
        {
            if (id != servicoViewModel.Id)return NotFound();

            var servicoAtualizacao = await ObterServico(id);
            servicoViewModel.Cliente = servicoAtualizacao.Cliente;

            if (!ModelState.IsValid) return NotFound();

            servicoAtualizacao.Nome = servicoViewModel.Nome;
            servicoAtualizacao.Descricao = servicoViewModel.Descricao;
            servicoAtualizacao.Valor = servicoViewModel.Valor;
            servicoAtualizacao.DataServico = servicoViewModel.DataServico;
            await _servicoRepository.Atualizar(_mapper.Map<Servico>(servicoAtualizacao));

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(Guid id)
        {
            var servico = await ObterServico(id);
            if (servico == null) return NotFound();

            return View(servico);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var servico = await ObterServico(id);

            if (servico == null) return NotFound();

            await _servicoRepository.Remover(id);

            return RedirectToAction("Index");
        }

        private async Task<ServicoViewModel> ObterServico(Guid id)
        {
            var servico = _mapper.Map<ServicoViewModel>(await _servicoRepository.ObterServicoCliente(id));

            servico.Clientes = _mapper.Map<IEnumerable<ClienteViewModel>>(await _clienteRepository.ObterPorId(id));
                       
            return servico;
        }
        private async Task<ServicoViewModel> PopularClientes(ServicoViewModel servico)
        {
            servico.Clientes = _mapper.Map<IEnumerable<ClienteViewModel>>(await _clienteRepository.ObterTodos());
            return servico;
        }

    }
}
