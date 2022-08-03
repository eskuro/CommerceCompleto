namespace IServicios.MotivoBaja
{
    public interface IMotivoBajaServicio : IServicios.Base.IServicio
    {
        bool VerificarSiExiste(string datoVerificar, long? entidadId = null);
    }
}
