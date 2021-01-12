namespace BladeRondo.System
{
    public interface IFactory<T> 
    {
        T Create(string str);
    }
}