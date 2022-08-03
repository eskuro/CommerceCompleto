namespace IServicios.Deposito
{
    public interface IDepositoSevicio : Base.IServicio
    {
        bool VerificarSiExiste(string datoVerificar, long? entidadId = null);
    }
}
