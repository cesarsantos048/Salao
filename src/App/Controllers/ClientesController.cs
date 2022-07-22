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
            [FromQuery] int page = 1,
            [FromQuery] int take = 3
            )
        {

            var total = await _clienteRepository.Total();

            ViewBag.page = page;
            ViewBag.take = take;
            ViewBag.total = total;

            if(take > total)
            {
                take = total;
            }

            int skip = 0;
            if (page > 1)
            {
                skip = (int)(take * (page - 1));
            }

            var data = _mapper.Map<IEnumerable<ClienteViewModel>>(await _clienteRepository.Ordenar(skip, take));
            return View(data);
        }



        public async Task<IActionResult> Details(Guid id)
        {
            var clienteViewModel = await ObterClienteServicos(id);
            if (clienteViewModel == null) return NotFound();

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
