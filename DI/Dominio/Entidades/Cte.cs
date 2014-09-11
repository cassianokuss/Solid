namespace DI.Dominio.Entidades
{
    public class Cte
    {
        public string PropriedadesDoCTe { get; set; }

        public static Cte ObterCte(string conteudo)
        {
            return new Cte
            {
                PropriedadesDoCTe = conteudo
            };
        }
    }
}