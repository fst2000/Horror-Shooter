public class DelegateInputConsumer<T> : IInputConsumer<T>
{
    InputConsumerDelegate<T> action;

    public DelegateInputConsumer(InputConsumerDelegate<T> action)
    {
        this.action = action;
    }

    public void Consume(T input)
    {
        action(input);
    }
}
public delegate void InputConsumerDelegate<T>(T input);