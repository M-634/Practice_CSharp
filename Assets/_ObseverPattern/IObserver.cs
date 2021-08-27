
namespace DesignPatterns.Observer
{
    public interface IObserver<T>
    {
        void OnNext(T value);
    }
}
