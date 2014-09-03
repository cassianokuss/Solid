using System;

namespace Solid.Inicio
{
    public class ProcessaDocumento
    {
        public void Processar(Documento doc)
        {
            switch (doc.Tipo)
            {
                case TipoDocumento.NFe:
                    if (doc.Conteudo != null && doc.Conteudo.Contains("NFe"))
                    {
                        var nfe = new NFe() { PropriedadesDaNFe = doc.Conteudo };
                        ArmazenarNFe(nfe);
                        EnviarEmail("NFe enviada! " + doc.Conteudo);
                    }
                    break;
                case TipoDocumento.NFCe:
                    if (doc.Conteudo != null && doc.Conteudo.Contains("NFCe"))
                    {
                        var nfce = new NFCe() { PropriedadesDaNFCe = doc.Conteudo };
                        ArmazenarNFCe(nfce);
                        EnviarEmail("NFCe enviada! " + doc.Conteudo);
                    }
                    break;
                case TipoDocumento.CTe:
                    if (doc.Conteudo != null && doc.Conteudo.Contains("CTe"))
                    {
                        var cte = new CTe() { PropriedadesDoCTe = doc.Conteudo };
                        ArmazenarCTe(cte);
                        EnviarEmail("CTe enviado! " + doc.Conteudo);
                    }
                    break;
            }
        }

        private void ArmazenarNFe(NFe nfe)
        {
            Console.WriteLine("NFe armazenada!");
        }

        private void ArmazenarNFCe(NFCe nfce)
        {
            Console.WriteLine("NFCe armazenada!");
        }

        private void ArmazenarCTe(CTe cte)
        {
            Console.WriteLine("CTe armazenado!");
        }

        private void EnviarEmail(string conteudo)
        {
            Console.WriteLine(conteudo);
        }
    }
}
