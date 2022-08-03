using System.Collections.Generic;
using IServicios.Departamento.DTOs;

namespace IServicios.Departamento
{
    public interface IDepartamentoServicio : Base.IServicio
    {
        bool VerificarSiExiste(string datoVerificar, long idRelacional,  long? entidadId = null);

        IEnumerable<DepartamentoDto> ObtenerPorProvincia(long provinciaId);
    }
}
