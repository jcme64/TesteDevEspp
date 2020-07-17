using System.ComponentModel.DataAnnotations.Schema;
using System;

namespace ExameApi.ViewModel
{
	public partial class LancamentosViewModel
	{
		[Column("id_lancamento")]
		public int IdLancamento { get; set; }
		[Column("id_conta")]
		public int IdConta { get; set; }
		[Column("dt_lancamento")]
		public DateTime DtLancamento { get; set; }
		[Column("vl_lancamento")]
		public decimal ValorLancamento { get; set; }
		[Column("nm_conta")]
		public string NumeroConta { get; set; }
	}
}
