using Locadora.Domain.Interfaces;
using Locadora.Domain.Models;
using Locadora.Infra.Data.Context;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Locadora.Infra.Data.Repository
{
    public class ItemLocacaoRepository : Repository<ItemLocacao>, IItemLocacaoRepository
    {
        public ItemLocacaoRepository(LocadoraContext context) : base(context) { }
    }
}