using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Touchpad : MonoBehaviour, IInput, IBeginDragHandler, IDragHandler, IEndDragHandler, IPointerUpHandler, IPointerDownHandler
{
    Vector2 input;
    Vector2 start;
    public void GiveInput(IInputConsumer consumer)
    {
        consumer.Consume(input);
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        start = eventData.position;
    }

    public void OnDrag(PointerEventData eventData)
    {
        input = eventData.position - start;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        input = Vector2.zero;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        start = eventData.position;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        input = Vector2.zero;
    }
}
