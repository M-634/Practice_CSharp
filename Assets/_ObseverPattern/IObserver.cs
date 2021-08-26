
namespace DesignPatterns.Observer
{
    public interface IObserver
    {
        //Recive update from subject.
        void Update(ISubject subject);
    }
}
