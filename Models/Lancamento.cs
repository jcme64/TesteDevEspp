using System;

namespace ExameApi.Models
{
	public partial class Lancamento
	{
		public int IdLancamento { get; set; }
		public int IdConta { get; set; }
		public DateTime DtLancamento { get; set; }
		public decimal ValorLancamento { get; set; }
	}
}
