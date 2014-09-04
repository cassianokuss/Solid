namespace DI.Dominio.Servicos.Documentos
{
    public interface IProcessaDocumento : IEstrategiaTipoDocumento
    {
        void Processar(string conteudo);
    }
}
