namespace IServicios.ConceptoGasto
{
    public interface IConceptoGastoServicio : IServicios.Base.IServicio
    {
        bool VerificarSiExiste(string datoVerificar, long? entidadId = null);
    }
}
