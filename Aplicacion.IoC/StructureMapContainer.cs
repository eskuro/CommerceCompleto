using System.Data.Entity;
using Dominio.Repositorio;
using Dominio.UnidadDeTrabajo;
using Infraestructura.Repositorio;
using Infraestructura.UnidadDeTrabajo;
using IServicios.Articulo;
using IServicios.Configuracion;
using IServicios.Departamento;
using IServicios.Deposito;
using IServicios.Iva;
using IServicios.ListaPrecio;
using IServicios.Localidad;
using IServicios.Marca;
using IServicios.Persona;
using IServicios.Provincia;
using IServicios.Rubro;
using IServicios.Seguridad;
using IServicios.UnidadMedida;
using IServicios.Usuario;
using IServicios.BajaArticulo;
using IServicios.ConceptoGasto;
using IServicios.Contador;
using IServicios.MotivoBaja;
using IServicios.Precio;
using Servicios.Articulo;
using Servicios.BajaArticulo;
using Servicios.ConceptoGastos;
using Servicios.CondicionIva;
using Servicios.Configuracion;
using Servicios.Departamento;
using Servicios.Deposito;
using Servicios.Iva;
using Servicios.ListaPrecio;
using Servicios.Localidad;
using Servicios.Marca;
using Servicios.Persona;
using Servicios.Provincia;
using Servicios.Rubro;
using Servicios.Seguridad;
using Servicios.UnidadMedida;
using Servicios.Usuario;
using StructureMap;
using IServicios.PuestoTrabajo;
using Servicios.Contador;
using Servicios.MotivoBaja;
using Servicios.Precio;
using Servicios.PuestoTrabajo;
using IServicios.Caja;
using Servicios.Caja;
using IServicios.Banco;
using Servicios.Banco;
using Servicios.Tarjeta;
using IServicios.Tarjeta;
using IServicios.Comprobante;
using Servicios.Comprobante;
using Servicios.CuentaCorriente;
using IServicios.CuentaCorriente;

namespace Aplicacion.IoC
{
    public class StructureMapContainer
    {
        public void Configure()
        {
            ObjectFactory.Configure(x =>
            {
                x.For(typeof(IRepositorio<>)).Use(typeof(Repositorio<>));

                x.ForSingletonOf<DbContext>();

                x.For<IUnidadDeTrabajo>().Use<UnidadDeTrabajo>();

                // =================================================================== //

                x.For<IProvinciaServicio>().Use<ProvinciaServicio>();

                x.For<IDepartamentoServicio>().Use<DepartamentoServicio>();

                x.For<ILocalidadServicio>().Use<LocalidadServicio>();

                x.For<ICondicionIvaServicio>().Use<CondicionIvaServicio>();

                x.For<IPersonaServicio>().Use<PersonaServicio>();

                x.For<IClienteServicio>().Use<ClienteServicio>();

                x.For<IEmpleadoServicio>().Use<EmpleadoServicio>();

                x.For<IUsuarioServicio>().Use<UsuarioServicio>();

                x.For<ISeguridadServicio>().Use<SeguridadServicio>();

                x.For<IConfiguracionServicio>().Use<ConfiguracionServicio>();

                x.For<IListaPrecioServicio>().Use<ListaPrecioServicio>();

                x.For<IBajaArticuloServicio>().Use<BajaArticuloServicio>();

                x.For<IArticuloServicio>().Use<ArticuloServicio>();

                x.For<IMarcaServicio>().Use<MarcaServicio>();

                x.For<IRubroServicio>().Use<RubroServicio>();

                x.For<IUnidadMedidaServicio>().Use<UnidadMedidaServicio>();

                x.For<IIvaServicio>().Use<IvaServicio>();

                x.For<IConceptoGastoServicio>().Use<ConceptoGastoServicio>();

                x.For<IDepositoSevicio>().Use<DepositoServicio>();

                x.For<IPuestoTrabajoServicio>().Use<PuestoTrabajoServicio>();

                x.For<IMotivoBajaServicio>().Use<MotivoBajaServicio>();

                x.For<ITarjetaServicio>().Use<TarjetaServicio>();

                x.For<IContadorServicio>().Use<ContadorServicio>();

                x.For<IPrecioServicio>().Use<PrecioServicio>();

                x.For<ICajaServicio>().Use<CajaServicio>();

                x.For<IBancoServicio>().Use<BancoServicio>();

                x.For<ITarjetaServicio>().Use<TarjetaServicio>();

                x.For<IFacturaServicio>().Use<FacturaServicio>();

                x.For<ICuentaCorrienteServicio>().Use<CuentaCorrienteServicio>();

                x.For<ICuentaCorrienteComprobanteServicio>().Use<CuentaCorrienteComprobanteServicio>();
            });
        }
    }
}
