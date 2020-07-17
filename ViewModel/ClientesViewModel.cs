using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExameApi.ViewModel
{
	public class ClientesViewModel
    {
        [Column("id_cliente")]
        public int IdCliente { get; set; }
        [Column("nm_cliente")]
        public string NomeCliente { get; set; }
        [Column("cpf_cnpj")]
        public string CpfCnpj { get; set; }
        [Column("tp_cliente")]
        public string TpCliente { get; set; }
        [Column("eMail")]
        public string EMail { get; set; }
        public string CpfCnpjFormatado
        {
            get
            {
                if (CpfCnpj != null && CpfCnpj.Length == 11)
                {
                    MaskedTextProvider mascara = new MaskedTextProvider("000\\.000\\.000\\-00");
                    mascara.Set(CpfCnpj);
                    return mascara.ToString();

                }
                else if (CpfCnpj != null && CpfCnpj.Length == 14)
                {
                    MaskedTextProvider mascara = new MaskedTextProvider("00\\.000\\.000\\/0000\\-00");
                    mascara.Set(CpfCnpj);
                    return mascara.ToString();
                }
                else
                    return "";
            }
        }
                   
        public string TipoCliente
        {
            get
            {
                if(TpCliente == "J")
                    return "Jurídica";
                else if(TpCliente == "F")
                    return "Física";
                else
                    return "";
            }
        }
    }    
}
