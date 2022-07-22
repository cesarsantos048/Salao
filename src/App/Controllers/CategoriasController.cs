using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using App.ViewModels;
using Business.Interfaces;
using AutoMapper;
using Business.Models;

namespace App.Controllers
{
    public class CategoriasController : Controller
    {
        private readonly ICategoriaRepository _categoriaRepository;
        private readonly IMapper _mapper;

        public CategoriasController(ICategoriaRepository categoriaRepository,
                                    IMapper mapper)
        {
            _categoriaRepository = categoriaRepository;
            _mapper = mapper;
        }


        public async Task<IActionResult> Index()
        {
            return View(await _categoriaRepository.ObterTodos());
        }

        public async Task<IActionResult> Details(Guid id)
        {
            var categoria = await ObterCategoria(id);
            if (categoria == null) return NotFound();
            return View(categoria);
        }

        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CategoriaViewModel categoriaViewModel)
        {

            if (!ModelState.IsValid) return View(categoriaViewModel);

            var categoria = _mapper.Map<Categoria>(categoriaViewModel);
            await _categoriaRepository.Adicionar(categoria);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Edit(Guid id)
        {
            var categoria = await ObterCategoria(id);
            if (categoria == null)
            {
                return NotFound();
            }
            return View(categoria);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, CategoriaViewModel categoriaViewModel)
        {
            if (id != categoriaViewModel.Id) return NotFound();

            if (!ModelState.IsValid) return View(categoriaViewModel);

            var cliente = _mapper.Map<Categoria>(categoriaViewModel);
            await _categoriaRepository.Atualizar(cliente);

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(Guid id)
        {
            var categoria = await ObterCategoria(id);
            if (categoria == null) return NotFound();

            return View(categoria);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var categoria = await ObterCategoria(id);

            if (categoria == null) return NotFound();

            await _categoriaRepository.Remover(id);

            return RedirectToAction("Index");
        }

        private async Task<CategoriaViewModel> ObterCategoria(Guid id)
        {
            var teste = _mapper.Map<CategoriaViewModel>(await _categoriaRepository.ObterCategoriaProdutos(id));
            return teste;
        }
    }
}
