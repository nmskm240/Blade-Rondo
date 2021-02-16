namespace BladeRondo.System
{
    public interface IObserver<T>
    {
        void ReceiveNotify(T data);
    }
}