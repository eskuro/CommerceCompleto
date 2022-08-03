using System.Collections.Generic;
using IServicios.Localidad.DTOs;

namespace IServicios.Localidad
{
    public interface ILocalidadServicio : Base.IServicio
    {
        bool VerificarSiExiste(string datoVerificar, long idRelacional, long? entidadId = null);

        IEnumerable<LocalidadDto> ObtenerPorDepartamento(long departamentoId);
    }
}
