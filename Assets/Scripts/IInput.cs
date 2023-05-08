public interface IInput<T>
{
    void GiveInput(IInputConsumer<T> consumer);
}