using Microsoft.EntityFrameworkCore;
using NTTData.Application.Interfaces.IRepository;
using NTTData.Core.Entities;
using NTTData.Infrastructure.DATA.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTTData.Infrastructure.DATA.Repository
{
    public class CuentaRepository : ICuentaRepository
    {
        private readonly BaseDataContext _context;
        public CuentaRepository(BaseDataContext context)
        {
            _context = context;
        }

        public bool ActualizarCuenta(CuentaEntrada cuenta, ref string mensaje)
        {
            bool bandera = false;
            if (_context.Personas.Where(x => x.Identificacion == cuenta.Identificacion).Count() > 0)
            {
                var resutl2 = (from p in _context.Personas
                                   from c in _context.Clientes
                                   where c.Personaid == p.Personaid && p.Identificacion == cuenta.Identificacion
                               select new 
                                   {   Clienteid = c.Clienteid
                                       
                                   }
                          ).First().Clienteid;

                int idcliente = resutl2;


                if (_context.Cuenta.Where(x => x.Clienteid == idcliente && x.Tipocuenta == cuenta.tipocuenta).Count() > 0)
                {
                    var result = _context.Cuenta.Where(x => x.Clienteid == idcliente && x.Tipocuenta == cuenta.tipocuenta).ToList();

                    //var CuentaUpdate = new Cuenta()
                    //{
                    //    Numerocuenta = cuenta.numerocuenta,
                    //    Tipocuenta = cuenta.tipocuenta,
                    //    SaldoInicial = cuenta.saldoInicial,
                    //    Clienteid = idcliente,
                    //    Estado = cuenta.Estado
                    //};

                    Cuenta ItemCuenta = null;                
                        
                    foreach (var icta in result)
                    {
                        ItemCuenta = new Cuenta()
                        {
                            Cuentaid= icta.Cuentaid,
                            Estado= icta.Estado,
                            Clienteid= icta.Clienteid,  
                            Numerocuenta= icta.Numerocuenta,
                            SaldoInicial= icta.SaldoInicial,
                            Tipocuenta=icta.Tipocuenta
                        };
                    }

                    ItemCuenta.Numerocuenta = cuenta.numerocuenta;
                    ItemCuenta.SaldoInicial = cuenta.saldoInicial;
                    _context.ChangeTracker.Clear();
                    _context.Update(ItemCuenta);
                    var dat = _context.SaveChanges();

                    if (dat > 0)
                    {
                        bandera = true;
                        mensaje = "Se actualizo la cuenta";
                        return bandera;
                    }
                    else
                    {
                        bandera = false;
                        mensaje = "Error al actualizar la cuenta";
                        return bandera;
                    }
                    
                }
                else
                {
                    mensaje = "No existe cuenta";
                    return bandera;
                }

                    

            }
            else
            {
                mensaje = "Usuario no existe";
                return bandera;
            }
             
        }

        public async Task<List<CuentaResult>> ConsultarCuenta(string? identificacion, string? numeroCuenta)
        {
            var resutl = await(from p in _context.Personas
                               from c in _context.Clientes
                               from v in _context.Cuenta
                               where c.Personaid == p.Personaid && c.Clienteid == v.Clienteid && p.Identificacion == identificacion && v.Numerocuenta == numeroCuenta
                               select new CuentaResult()
                               {
                                   Numerocuenta = v.Numerocuenta,
                                   Tipocuenta= v.Tipocuenta,
                                   SaldoInicial = v.SaldoInicial,
                                   Estado= v.Estado
                               }
                         ).ToListAsync();

            return resutl;
        }

        public bool EliminarCuenta(string? identificacion, string? numeroCuenta, bool? estado, ref string mensaje)
        {
            bool bandera = false;
            if (_context.Personas.Where(x => x.Identificacion == identificacion).Count() > 0)
            {
                var resutl2 = (from p in _context.Personas
                               from c in _context.Clientes
                               from v in _context.Cuenta
                               where c.Personaid == p.Personaid && v.Clienteid == c.Clienteid && p.Identificacion == identificacion && v.Numerocuenta == numeroCuenta

                               select new
                               {
                                   Cuentaid = v.Cuentaid

                               }
                          ).First().Cuentaid;

                int idcuenta = resutl2;


                if (idcuenta > 0)
                {
                    var result = _context.Cuenta.Where(x => x.Cuentaid == idcuenta).ToList();

                    Cuenta ItemCuenta = null;

                    foreach (var icta in result)
                    {
                        ItemCuenta = new Cuenta()
                        {
                            Cuentaid = icta.Cuentaid,
                            Estado = icta.Estado,
                            Clienteid = icta.Clienteid,
                            Numerocuenta = icta.Numerocuenta,
                            SaldoInicial = icta.SaldoInicial,
                            Tipocuenta = icta.Tipocuenta
                        };
                    }

                    ItemCuenta.Estado = estado;
                    _context.ChangeTracker.Clear();
                    _context.Update(ItemCuenta);
                    var dat = _context.SaveChanges();

                    if (dat > 0)
                    {
                        bandera = true;
                        mensaje = "Se actualizo la cuenta";
                        return bandera;
                    }
                    else
                    {
                        bandera = false;
                        mensaje = "Error al actualizar la cuenta";
                        return bandera;
                    }
                }
                else
                {
                    mensaje = "No existe cuenta";
                    return bandera;
                }
            }
            else
            {
                mensaje = "Usuario no existe";
                return bandera;
            }
        }

        public bool IngresarCuenta(CuentaEntrada cuenta, ref string mensaje)
        {
            bool bandera = false;
            if (_context.Personas.Where(x => x.Identificacion == cuenta.Identificacion).Count() > 0)
            {
                var resutl2 = (from p in _context.Personas
                               from c in _context.Clientes
                               where c.Personaid == p.Personaid && p.Identificacion == cuenta.Identificacion
                               select new
                               {
                                   Clienteid = c.Clienteid

                               }
                          ).First().Clienteid;

                int idcliente = resutl2;

                if (_context.Cuenta.Where(x => x.Clienteid == idcliente && x.Tipocuenta == cuenta.tipocuenta).Count() > 0)
                {
                    mensaje = "El usuario ya tiene registrado la cuenta - " + cuenta.tipocuenta;
                    return bandera;                  
                }
                else
                {
                    _context.ChangeTracker.Clear();

                    _context.Add(new Cuenta()
                    {
                        Numerocuenta = cuenta.numerocuenta,
                        Tipocuenta = cuenta.tipocuenta,
                        SaldoInicial = cuenta.saldoInicial,
                        Clienteid = idcliente,
                        Estado = cuenta.Estado
                    });
                    var dat = _context.SaveChanges();

                    if (dat > 0)
                    {
                        bandera = true;
                        mensaje = "Se creo la cuenta";
                        return bandera;
                    }
                    else
                    {
                        bandera = false;
                        mensaje = "Error al crear la cuenta";
                        return bandera;
                    }
                }
            }
            else
            {
                mensaje = "Usuario no existe";
                return bandera;
            }
        }
    }
}
