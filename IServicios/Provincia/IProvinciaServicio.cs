﻿namespace IServicios.Provincia
{
    public interface IProvinciaServicio : Base.IServicio
    {
        bool VerificarSiExiste(string datoVerificar, long? entidadId = null);
    }
}
