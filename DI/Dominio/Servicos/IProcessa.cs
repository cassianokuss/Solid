namespace DI.Dominio.Servicos
{
    using Entidades;

    public interface IProcessa
    {
        void ProcessarDocumento(DocumentoXml documento);
    }
}