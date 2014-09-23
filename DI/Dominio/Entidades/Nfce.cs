namespace DI.Dominio.Entidades
{
    public class Nfce
    {
        public string PropriedadesDaNFCe { get; set; }

        public static Nfce ObterNfce(string conteudo)
        {
            return new Nfce
            {
                PropriedadesDaNFCe = conteudo
            };
        }
    }
}