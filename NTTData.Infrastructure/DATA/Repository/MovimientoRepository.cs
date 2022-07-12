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

        public async Task<List<MovimientoResult>> ConsultaMovimiento(MovimientoEntrada realizamovi)
        {
            List<MovimientoResult> ListSal = new List<MovimientoResult>();

            DateTime FechaI = Convert.ToDateTime(realizamovi.FechaInicio);
            DateTime FechaF = Convert.ToDateTime(realizamovi.FechaFinal);
            string FechaInicio = FechaI.ToString("yyyy-MM-dd");
            string FechaFin = FechaF.ToString("yyyy-MM-dd");


            string sql = $"EXECUTE dbo.Sp_Consulta_Movimiento " +
                                          "@fechaI," +
                                          "@fechaf," +
                                          "@identificacion";

            var lst = _context.movimientoConsulta.FromSqlRaw(sql, new List<SqlParameter>
            {
                new SqlParameter { ParameterName = "@fechaI", SqlDbType = SqlDbType.NVarChar, Value = FechaInicio },
                new SqlParameter { ParameterName = "@fechaf", SqlDbType = SqlDbType.NVarChar, Value =FechaFin  },
                new SqlParameter { ParameterName = "@identificacion", SqlDbType = SqlDbType.NVarChar, Value =realizamovi.Identificacion},

            }.ToArray()).ToList();

            foreach (var item in lst)
            {
                ListSal.Add(new MovimientoResult()
                {
                    Cliente = item.Cliente,
                    estado = item.estado,
                    fecha = item.fecha,
                    Movimiento = item.Movimiento,
                    NumeroCuenta = item.NumeroCuenta,
                    SaldoDisponible = item.SaldoDisponible,
                    saldoinicial = item.saldoinicial,
                    Tipo=item.Tipo
                    

                });
            }

            return ListSal;
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
