namespace DI.Dominio.Servicos.Documentos.Validacoes
{
    public interface IValidaXml : IEstrategiaTipoDocumento
    {
        void Validar(string documento);
    }
}