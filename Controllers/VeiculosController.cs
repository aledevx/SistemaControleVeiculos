using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SistemaControleVeiculos.Data;
using SistemaControleVeiculos.Models;
using SistemaControleVeiculos.Services;

namespace SistemaControleVeiculos.Controllers
{
    public class VeiculosController : Controller
    {
        private readonly Contexto _context;
        private readonly GeradorListas _geradorListas;

        public VeiculosController(Contexto context, GeradorListas geradorListas)
        {
            _context = context;
            _geradorListas = geradorListas;
        }

        public async Task<ActionResult<IEnumerable<Veiculo>>> Index()
        {

            var veiculos = await _context.Veiculos.ToListAsync();

            return View(veiculos);
        }

        public IActionResult Criar()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Criar(Veiculo veiculo)
        {
            veiculo.Status = Constantes.Status.Disponivel;
            _context.Add(veiculo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Detalhes(int id)
        {
            var veiculo = _context.Veiculos.Find(id);
            return View(veiculo);
        }

        public async Task<IActionResult> Editar(int? id)
        {
            var veiculo = await _context.Veiculos.FindAsync(id);
            return View(veiculo);
        }

        [HttpPost]
        public async Task<IActionResult> Editar(Veiculo veiculo)
        {
            _context.Update(veiculo);
            await _context.SaveChangesAsync();
            return View(veiculo);
        }

    }
}