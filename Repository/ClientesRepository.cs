using ExameApi.ViewModel;
using ExameApi.Models;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ExameApi.Repository
{
    public class ClientesRepository : IClientesRepository
    {
        DatabaseContext db;
        public ClientesRepository(DatabaseContext _db)
        {
            db = _db;
        }

        public async Task<List<ClientesViewModel>> GetAll()
        {
            if(db != null)
            {
                return await (from a in db.Clientes
                              select new ClientesViewModel
                              {
                                  IdCliente = a.IdCliente,
								  NomeCliente = a.NomeCliente,
                                  CpfCnpj = a.CpfCnpj,
                                  TpCliente = a.TpCliente,
                                  EMail = a.EMAil
                              }).ToListAsync();
            }

            return null;
        }

        public async Task<ClientesViewModel> Get(int Id)
        {
            if (db != null)
            {
                return await (from a in db.Clientes
                              where a.IdCliente == Id
                              select new ClientesViewModel
                              {
                                  IdCliente = a.IdCliente,
                                  NomeCliente = a.NomeCliente,
                                  CpfCnpj = a.CpfCnpj,
                                  TpCliente = a.TpCliente,
                                  EMail = a.EMAil
                              }).FirstOrDefaultAsync();
            }

            return null;
        }

        public async Task<int> Add(Clientes model)
        {
            if (db != null)
            {
                await db.Clientes.AddAsync(model);
                await db.SaveChangesAsync();

                return model.IdCliente;
            }

            return 0;
        }

        public async Task<int> Delete(int Id)
        {
            int result = 0;

            if (db != null)
            {
                //Find the post for specific post id
                var model = await db.Clientes.FirstOrDefaultAsync(x => x.IdCliente == Id);

                if (model != null)
                {
                    //Delete that post
                    db.Clientes.Remove(model);

                    //Commit the transaction
                    result = await db.SaveChangesAsync();
                }
                return result;
            }

            return result;
        }

        public async Task Update(Clientes model)
        {
            if (db != null)
            {
                //Delete that post
                db.Clientes.Update(model);

                //Commit the transaction
                await db.SaveChangesAsync();
            }
        }
    }
}
