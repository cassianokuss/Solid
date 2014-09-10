namespace DI.Dominio.Servicos.Documentos.Validadores
{
    public interface ValidadorDeXml : EstrategiaPorTipoDeDocumento
    {
        void Validar(string documento);
    }
}