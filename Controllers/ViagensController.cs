using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SistemaControleVeiculos.Data;
using SistemaControleVeiculos.Models;

namespace SistemaControleVeiculos.Controllers
{
    public class ViagensController : Controller
    {
        private readonly Contexto _context;

        public ViagensController(Contexto context)
        {
            _context = context;
        }

        public async Task<ActionResult<IEnumerable<Viagem>>> Index()
        {

            var viagens = await _context.Viagens.ToListAsync();

            return View(viagens);
        }

        public IActionResult Criar(int? veiculoId)
        {
            Viagem viagem = new Viagem();
            viagem.VeiculoId = Convert.ToInt32(veiculoId);
            return View(viagem);
        }

        [HttpPost]
        public async Task<IActionResult> Criar(Viagem viagem)
        {
            if (viagem.DataSaida >= viagem.DataRetorno)
            {
                ModelState.AddModelError("DataSaida", "A data de saída não pode ser maior que a data de retorno!");
            }


            var viagens = await _context.Viagens.Where(v => v.VeiculoId == viagem.VeiculoId && v.DataSaida >= DateTime.Now || v.DataRetorno >= DateTime.Now).ToListAsync();

            var viagens_datas = (from ViagemReservada in viagens
                                 select new
                                 {
                                    Id = ViagemReservada.Id,
                                    DataSaida = ViagemReservada.DataSaida,
                                    DataRetorno = ViagemReservada.DataRetorno
                                 });

            // VERIFICAR DATAS EM INTERVALOS DE DATAS









            _context.Add(viagem);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Detalhes(int id)
        {
            var viagem = await _context.Viagens.Include(v => v.Veiculo).FirstOrDefaultAsync(v => v.Id == id);
            return View(viagem);
        }

        public async Task<IActionResult> Editar(int? id)
        {
            var viagem = await _context.Viagens.Include(v => v.Veiculo).FirstOrDefaultAsync(v => v.Id == id);
            return View(viagem);
        }

        [HttpPost]
        public async Task<IActionResult> Editar(Viagem viagem)
        {
            _context.Update(viagem);
            await _context.SaveChangesAsync();
            return View(viagem);
        }
    }
}