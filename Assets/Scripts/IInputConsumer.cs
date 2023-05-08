using UnityEngine;
public interface IInputConsumer<T>
{
    void Consume(T input);
}