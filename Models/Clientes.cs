using System;

namespace ExameApi.Models
{
	public partial class Clientes
	{
		public int IdCliente { get; set; }
		public string NomeCliente { get; set; }
		public string CpfCnpj { get; set; }
		public string TpCliente { get; set; }
		public string EMAil { get; set; }
	}
}
