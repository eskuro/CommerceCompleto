﻿using Dominio.Entidades;
using Dominio.Repositorio;

namespace Dominio.UnidadDeTrabajo
{
    public interface IUnidadDeTrabajo
    {
        // Metodos
        void Commit();

        void Disposed();

        // Propiedades

        IRepositorio<Provincia> ProvinciaRepositorio { get; }
        IRepositorio<Departamento> DepartamentoRepositorio { get; }
        IRepositorio<Localidad> LocalidadRepositorio { get; }
        IRepositorio<CondicionIva> CondicionIvaRepositorio { get; }
        IClienteRepositorio ClienteRepositorio { get; }
        IEmpleadoRepositorio EmpleadoRepositorio { get; }
        IRepositorio<Usuario> UsuarioRepositorio { get; }
        IRepositorio<Configuracion> ConfiguracionRepositorio { get; }
        IRepositorio<ListaPrecio> ListaPrecioRepositorio { get; }
        IRepositorio<UnidadMedida> UnidadMedidaRepositorio { get; }
        IRepositorio<Marca> MarcaRepositorio { get; }
        IRepositorio<Rubro> RubroRepositorio { get; }
        IRepositorio<Iva> IvaRepositorio { get; }
        IRepositorio<Articulo> ArticuloRepositorio { get; }
        IRepositorio<Deposito> DepositoRepositorio { get; }
        IRepositorio<MotivoBaja> MotivoBajaRepositorio { get; }
        IRepositorio<BajaArticulo> BajaArticuloRepositorio { get; }
        IRepositorio<Precio> PrecioRepositorio { get; }
        IRepositorio<Stock> StockRepositorio { get; }
        IRepositorio<ConceptoGasto> ConceptoGastoRepositorio { get; }
        IRepositorio<PuestoTrabajo> PuestoTrabajoRepositorio { get; }
        IRepositorio<Banco> BancoRepositorio { get; }
        IRepositorio<MovimientoCuentaCorriente> MovimientoCuentaCorrienteRepositorio { get; }
        IRepositorio<Contador> ContadorRepositorio { get; }
        IRepositorio<Tarjeta> TarjetaRepositorio { get; }
        IRepositorio<Caja> CajaRepositorio { get; }
	    IFacturaRepositorio FacturaRepositorio { get; }

        ICtaCteClienteRepositorio CuentaClienteCorrienteRepositorio { get; }

        IRepositorio<DetalleCaja> DetalleCajaRepositorio { get; }

        ICuentaCorrienteRepositorio CuentaCorrienteRepositorio { get; }
    }
}
