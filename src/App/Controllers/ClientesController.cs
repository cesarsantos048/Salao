using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using App.ViewModels;
using Business.Interfaces;
using AutoMapper;
using Business.Models;

namespace App.Controllers
{
    public class ClientesController : BaseController
    {
        private readonly IClienteRepository _clienteRepository;
        private readonly IMapper _mapper;


        public ClientesController(IClienteRepository clienteRepository,
                                  IMapper mapper)
        {
            _clienteRepository = clienteRepository;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index(
            [FromQuery] int? skip,
            [FromQuery] int? take)
        {
            if (take > 100)
                return View();

            var data = _mapper.Map<IEnumerable<ClienteViewModel>>(await _clienteRepository.Ordenar(skip ?? 0, take ?? 10));
            return View(data);
        }



        public async Task<IActionResult> Details(Guid id)
        {
            var clienteViewModel = await ObterClienteServicos(id);
            if (clienteViewModel == null)
            {
                return NotFound();
            }

            return View(clienteViewModel);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ClienteViewModel clienteViewModel)
        {
            if (!ModelState.IsValid) return View(clienteViewModel);

            var cliente = _mapper.Map<Cliente>(clienteViewModel);
            await _clienteRepository.Adicionar(cliente);
            return RedirectToAction("Index");
            
        }

        public async Task<IActionResult> Edit(Guid id)
        {

            var clienteViewModel = await ObterClienteServicos(id);
            if (clienteViewModel == null)
            {
                return NotFound();
            }
            return View(clienteViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, ClienteViewModel clienteViewModel)
        {
            if (id != clienteViewModel.Id) return NotFound();

            if (!ModelState.IsValid) return View(clienteViewModel);

            var cliente = _mapper.Map<Cliente>(clienteViewModel);
            await _clienteRepository.Atualizar(cliente);

            return RedirectToAction("Index");
            
        }

        public async Task<IActionResult> Delete(Guid id)
        {
            var clienteViewModel = await ObterClienteServicos(id);
            if (clienteViewModel == null) return NotFound();

            return View(clienteViewModel);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var clienteViewModel = await ObterClienteServicos(id);

            if (clienteViewModel == null) return NotFound();

            await _clienteRepository.Remover(id);

            return RedirectToAction("Index");
        }

        private async Task<ClienteViewModel> ObterClienteServicos(Guid id)
        {
            return _mapper.Map<ClienteViewModel>(await _clienteRepository.ObterClienteServicos(id));
        }

    }
}
