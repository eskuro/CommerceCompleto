namespace IServicios.Departamento
{
    public interface ICondicionIvaServicio : Base.IServicio
    {
        bool VerificarSiExiste(string datoVerificar, long? entidadId = null);
    }
}
