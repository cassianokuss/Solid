namespace DI.Dominio.Entidades
{
    public class Cte
    {
        public Cte(string conteudo)
        {
            PropriedadesDoCTe = conteudo;
        }

        public string PropriedadesDoCTe { get; set; }
    }
}