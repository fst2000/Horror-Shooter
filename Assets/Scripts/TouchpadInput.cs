using UnityEngine;

public class TouchpadInput : IInput<Vector2>
{
    Vector2 input;

    public TouchpadInput(Vector2 input)
    {
        this.input = input;
    }

    public void GiveInput(IInputConsumer<Vector2> consumer)
    {
        consumer.Consume(input);
    }
}