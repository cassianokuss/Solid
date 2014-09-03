namespace Solid.SRP.Dominio.Servicos
{
    using Entidades;
    using Documento;

    public class ProcessaDocumento
    {
        public void Processar(DocumentoXml doc)
        {
            switch (doc.Tipo)
            {
                case TipoDocumento.NFe:
                    var processarNFe = new ProcessaNfe();
                    processarNFe.Processar(doc);
                    break;
                case TipoDocumento.NFCe:
                    var processarNFCe = new ProcessaNfce();
                    processarNFCe.Processar(doc);
                    break;
                case TipoDocumento.CTe:
                    var processarCTe = new ProcessaCte();
                    processarCTe.Processar(doc);
                    break;
            }
        }
    }
}
