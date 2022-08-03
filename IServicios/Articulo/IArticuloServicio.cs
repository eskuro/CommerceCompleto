using System.Collections.Generic;
using IServicios.Articulo.DTOs;

namespace IServicios.Articulo
{
    public interface IArticuloServicio : Base.IServicio
    {
        bool VerificarSiExiste(string datoVerificar, long? entidadId = null);

        int ObtenerSiguienteNroCodigo();

        int ObtenerCantidadArticulos();

        ArticuloVentaDto ObtenerPorCodigo(string codigo, long listaPrecioId, long depositoId);

        IEnumerable<ArticuloVentaDto> ObtenerLookUp(string cadenaBuscar, long listaPrecioId);
    }
}
