using System.Collections.Generic;
using IServicios.BaseDto;

namespace IServicios.Base
{
    public interface IServicioConsulta
    {
        DtoBase Obtener(long id);

        IEnumerable<DtoBase> Obtener(string cadenaBuscar, bool mostrarTodos = true);
    }
}
