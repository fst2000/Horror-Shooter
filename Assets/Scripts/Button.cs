using UnityEngine.EventSystems;
using UnityEngine;
public class Button : MonoBehaviour, IInput<bool>, IPointerClickHandler
{
    bool input;
    IInputConsumer<bool> consumer;
    public void GiveInput(IInputConsumer<bool> consumer)
    {
        consumer.Consume(input);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        input = !input;
    }
}