using UnityEngine;
public class RenderBoolInputConsumer : IInputConsumer<bool>
{
    GameObject renderer;
    public RenderBoolInputConsumer(GameObject render)
    {
        this.renderer = render;
    }

    public void Consume(bool input)
    {
        if(renderer.activeInHierarchy != input)renderer.SetActive(input);
    }
}