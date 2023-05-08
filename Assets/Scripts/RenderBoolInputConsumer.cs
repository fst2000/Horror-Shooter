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
        renderer.SetActive(input);
    }
}