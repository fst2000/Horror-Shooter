using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Touchpad : MonoBehaviour, IInput, IDragHandler
{
    RectTransform touchpad;
    Vector2 input;
    public void GiveInput(IInputConsumer consumer)
    {
        consumer.Consume(input);
    }
    public void OnDrag(PointerEventData eventData)
    {
        input = eventData.delta;
    }
    void Update()
    {
        input = Vector2.zero;
    }
}
