namespace DI.Dominio.Servicos.Documento
{
    using DI.Dominio.Entidades;

    public interface IValidaXml
    {
        void Validar(string documento);
        bool ValidarQuando(TipoDocumento tipo);
    }
}