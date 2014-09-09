namespace DI.Dominio.Repositorios
{
    public interface Repositorio<T>
    {
        void Armazenar(T entidade);
    }
}