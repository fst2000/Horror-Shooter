using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Touchpad : MonoBehaviour, IDragHandler
{
    Vector2 input;
    public void OnDrag(PointerEventData eventData)
    {
        input = eventData.delta;
    }
    public IInput<Vector2> Input()
    {
        TouchpadInput touchpadInput = new TouchpadInput(input);
        input = Vector2.zero;
        return touchpadInput;
    }
}
