using Microsoft.EntityFrameworkCore;
using SiteLanches.Context;
using SiteLanches.Models;

namespace SiteLanches.Areas.Admin.Servicos
{
    public class RelatorioVendasService
    {

        private readonly AppDbContext context;

        public RelatorioVendasService(AppDbContext _context)
        {
            context = _context;
        }


        public async Task<List<Pedido>> FindByDateAsync(DateTime? minDate, DateTime? maxDate)
        {

            //iquerable pra usar itens na memoria
            var resultado = from obj in context.Pedidos select obj;

            if (minDate.HasValue) resultado.Where(x => x.PedidoEnviado >= minDate);
            if (maxDate.HasValue) resultado.Where(x => x.PedidoEnviado <= maxDate);

            return await resultado.Include(l => l.PedidoItens)
                                  .ThenInclude(l => l.Lanche)
                                  .OrderByDescending(x => x.PedidoEnviado)
                                  .ToListAsync();


        }

    }


}
