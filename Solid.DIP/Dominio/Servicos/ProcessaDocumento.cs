namespace Solid.DIP.Dominio.Servicos
{
    using System;
    using Entidades;
    using Documento;

    public abstract class ProcessaDocumento
    {
        public abstract void Processar(string conteudo);

        public static ProcessaDocumento Instancia(TipoDocumento tipo)
        {
            switch (tipo)
            {
                case TipoDocumento.NFe:
                    return new ProcessaNfe();
                case TipoDocumento.NFCe:
                    return new ProcessaNfce();
                case TipoDocumento.CTe:
                    return new ProcessaCte();
                default:
                    throw new Exception("Não existe processamento para o documento!");
            }
        }
    }
}
