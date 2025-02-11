namespace TimeKeeping.DI_Factory;

public interface IFactory<T>
{
    T Create();
}
