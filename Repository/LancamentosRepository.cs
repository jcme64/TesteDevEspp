using ExameApi.ViewModel;
using ExameApi.Models;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ExameApi.Tools;

namespace ExameApi.Repository
{
    public class LancamentosRepository : ILancamentosRepository
    {
        DatabaseContext db;
        public LancamentosRepository(DatabaseContext _db)
        {
            db = _db;
        }

        public async Task<List<LancamentosViewModel>> GetAllByIdConta(int Id)
        {
            if (db != null)
            {
                return await (from a in db.Lancamentos
                              join b in db.Conta on a.IdConta equals b.IdConta
                              join c in db.Clientes on b.IdCliente equals c.IdCliente
                              where b.IdConta == Id
                              select new LancamentosViewModel
                              {
                                  IdLancamento = a.IdLancamento,
                                  IdConta = a.IdConta,
                                  NumeroConta = b.NumeroConta,
                                  DtLancamento = a.DtLancamento,
                                  ValorLancamento = a.ValorLancamento
                              }).ToListAsync();
            }

            return null;
        }

        public async Task<LancamentosViewModel> Get(int Id)
        {
            if (db != null)
            {
                return await (from a in db.Lancamentos
                              join b in db.Conta on a.IdConta equals b.IdConta
                              join c in db.Clientes on b.IdCliente equals c.IdCliente
                              where a.IdLancamento == Id
                              select new LancamentosViewModel
                              {
                                  IdLancamento = a.IdLancamento,
                                  IdConta = a.IdConta,
                                  NumeroConta = b.NumeroConta,
                                  DtLancamento = a.DtLancamento,
                                  ValorLancamento = a.ValorLancamento
                              }).FirstOrDefaultAsync();
            }

            return null;
        }

        public async Task<int> Add(Lancamento model)
        {
            if (db != null)
            {

                decimal tarifa = 0;
                await db.Lancamentos.AddAsync(model);
                await db.SaveChangesAsync();
                int idLancamento = model.IdLancamento;

                var contasRepository = new ContasRepository(db);
                var conta = await contasRepository.Get(model.IdConta);
                if (model.ValorLancamento < 0)
                {
                    if (conta.TpCliente == "J")
                    {
                        tarifa = (model.ValorLancamento * 5) / 100;
                    }
                    else
                    {
                        tarifa = (model.ValorLancamento * 2) / 100;
                    }
                }
                var newModel = new Lancamento();
                newModel.IdConta = model.IdConta;
                newModel.DtLancamento = DateTime.Now;
                newModel.ValorLancamento = tarifa;
                await db.Lancamentos.AddAsync(newModel);
                await db.SaveChangesAsync();

                var clientesRepository = new ClientesRepository(db);
                var cliente = await clientesRepository.Get(conta.IdCliente);
                string corpo = "Sr(a) " + cliente.NomeCliente;
                corpo += "o Valor R$" + model.ValorLancamento.ToString() + " foi lançado na sua conta supra citada.";

                EnviarEmail("Lançamento na conta:" + conta.NumeroConta, corpo, cliente.EMail);

                return idLancamento;
            }

            return 0;
        }

        private void EnviarEmail(string assunto, string mensagem, string endereco)
        {

            EMail eMail = new EMail();
            eMail.Client("smtp.gmail.com");

            eMail.Port = 587;

            eMail.FromAddress = "exames.dev@gmail.com";
            eMail.Acount = "exames.dev@gmail.com";
            eMail.PassWord = "EXDEV@01";
            eMail.EnableSsl = true;

            eMail.Subject = assunto;
            
            eMail.Body = mensagem.Replace("\\n", Environment.NewLine);
            eMail.AddTo(endereco);
            try
            {
                eMail.Send();

                eMail.ClearTo();
            } catch (Exception ex)
            { }
        }
    }
}
