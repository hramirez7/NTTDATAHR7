using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using NTTData.Application.Interfaces.IRepository;
using NTTData.Core.Entities;
using NTTData.Infrastructure.DATA.Context;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTTData.Infrastructure.DATA.Repository
{
    public class MovimientoRepository : IMovimientoRepository
    {
        private readonly BaseDataContext _context;

        public MovimientoRepository(BaseDataContext context)
        {
            _context = context;
        }

        public MovimientoRealizaResult CrearMovimiento(MovimientoRealizaEntrada realizamovi)
        {
            MovimientoRealizaResult salida = new MovimientoRealizaResult();

            string sql = $"EXECUTE dbo.Sp_Realizar_Movimientos " +
                                          "@identificaccion," +
                                          "@TipoCuenta," +
                                          "@movimientoValor," +
                                          "@tipoMovimiento";

            var lst = _context.movimientoRealiza.FromSqlRaw(sql, new List<SqlParameter>
            {
                new SqlParameter { ParameterName = "@identificaccion", SqlDbType = SqlDbType.VarChar, Value = realizamovi.Identificaccion  },
                new SqlParameter { ParameterName = "@TipoCuenta", SqlDbType = SqlDbType.VarChar, Value =realizamovi.TipoCuenta  },
                new SqlParameter { ParameterName = "@movimientoValor", SqlDbType = SqlDbType.Decimal, Value =realizamovi.MovimientoValor},
                new SqlParameter { ParameterName = "@tipoMovimiento", SqlDbType = SqlDbType.VarChar, Value =realizamovi.TipoMovimiento },

            }.ToArray()).ToList();
            foreach(var item in lst)
            {
                salida.mensaje = item.mensaje;
                salida.codigo = item.codigo;
            }



            return salida;
        }
    }
}
