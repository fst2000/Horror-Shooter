using UnityEngine;
using UnityEngine.EventSystems;
public class Joystick : MonoBehaviour, IInput<Vector2>, IBeginDragHandler, IDragHandler, IEndDragHandler, IPointerUpHandler, IPointerDownHandler
{
    Vector2 input;
    [SerializeField] RectTransform joystick;
    [SerializeField] RectTransform stick;
    [SerializeField] float shift;
    public void GiveInput(IInputConsumer<Vector2> consumer)
    {
        consumer.Consume(input);
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        input = Vector2.ClampMagnitude(eventData.position - (Vector2)joystick.position, shift) / shift;
        stick.anchoredPosition = input * shift;
    }

    public void OnDrag(PointerEventData eventData)
    {
        input = Vector2.ClampMagnitude(eventData.position - (Vector2)joystick.position, shift) / shift;
        stick.anchoredPosition = input * shift;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        input = Vector2.zero;
        stick.anchoredPosition = Vector2.zero;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        input = Vector2.ClampMagnitude(eventData.position - (Vector2)joystick.position, shift) / shift;
        stick.anchoredPosition = input * shift;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        input = Vector2.zero;
        stick.anchoredPosition = Vector2.zero;
    }
    
}