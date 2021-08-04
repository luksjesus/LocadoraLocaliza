using System;
using System.Collections.Generic;

namespace Locadora.Application.Filters.Financeiro
{
    public class LancamentoAppFilter
    {
        public int StatusLancamento { get; set; }
        public DateTime? DataEmissaoInicial { get; set; }
        public DateTime? DataEmissaoFinal { get; set; }
        public DateTime? DataVencimentoInicial { get; set; }
        public DateTime? DataVencimentoFinal { get; set; }
        public DateTime? DataPagamentoInicial { get; set; }
        public DateTime? DataPagamentoFinal { get; set; }
        public Double ValorInicial { get; set; }
        public Double ValorFinal { get; set; }
        public Double ValorPagoInicial { get; set; }
        public Double ValorPagoFinal { get; set; }
        public IEnumerable<Guid> CentroDeCusto { get; set; }
        public IEnumerable<Guid> FormaDePagamento { get; set; }
        public IEnumerable<Guid> Pessoa { get; set; }
        public IEnumerable<Guid> PlanoDeConta { get; set; }
        public IEnumerable<Guid> Conta { get; set; }
    }
}
