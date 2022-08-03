namespace IServicios.PuestoTrabajo
{
    public interface IPuestoTrabajoServicio : IServicios.Base.IServicio
    {
        bool VerificarSiExiste(string datoVerificar, long? entidadId = null);
    }
}
