namespace BladeRondo.System
{
    public interface IFactory<T> 
    {
        T Create(int i = 0);
    }
}