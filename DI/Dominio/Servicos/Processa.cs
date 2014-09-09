namespace DI.Dominio.Servicos
{
    using Entidades;

    public interface Processa
    {
        void ProcessarDocumento(DocumentoXml documento);
    }
}