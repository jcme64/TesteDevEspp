using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;


namespace ExameApi.ViewModel
{
	public partial class ContasViewModel
    {
        [Column("id_conta")]
        public int IdConta { get; set; }
        [Column("nm_conta")]
        public string NumeroConta { get; set; }
        [Column("id_cliente")]
        public int IdCliente { get; set; }
        [Column("nom_cliente")]
        public string NomeCliente { get; set; }
        [Column("cpf_cnpj")]
        public string CpfCnpj { get; set; }
        [Column("tp_cliente")]
        public string TpCliente { get; set; }
        
    }
}
