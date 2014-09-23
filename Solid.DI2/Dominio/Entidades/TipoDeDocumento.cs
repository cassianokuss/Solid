namespace Solid.DI2.Dominio.Entidades
{
    public interface IComparador<T>
    {
        bool Igual(T tipo);
    }

    public class TipoDeDocumento : IComparador<TipoDeDocumento>
    {
        public Tipo Tipo { get; set; }
        public int Versao { get; set; }

        public bool Igual(TipoDeDocumento tipo)
        {
            return Tipo == tipo.Tipo && ((tipo.Versao != 0 && tipo.Versao == Versao) || (tipo.Versao == 0));
        }
    }

    public enum Tipo
    {
        NFe,
        NFCe,
        CTe
    }
}