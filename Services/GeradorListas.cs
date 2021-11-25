using Microsoft.AspNetCore.Mvc.Rendering;
using SistemaControleVeiculos.Data;

namespace SistemaControleVeiculos.Services
{
    public class GeradorListas
    {
        private readonly Contexto _context;

        public GeradorListas(Contexto context)
        {
            _context = context;
        }

        public SelectListItem[] ListaStatus()
        {
            var lista = new[]{
                new SelectListItem () { Value = Constantes.Status.Disponivel, Text = Constantes.Status.Disponivel},
                new SelectListItem () { Value = Constantes.Status.EmViagem, Text = Constantes.Status.EmViagem},
                new SelectListItem () { Value = Constantes.Status.Reservado, Text = Constantes.Status.Reservado},
            };
            return lista;
        }

    }
}