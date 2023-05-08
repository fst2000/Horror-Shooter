using UnityEngine;

public class AnimatorVector2InputConsumer : IInputConsumer<Vector2>
{
    Animator animator;
    string blendX;
    string blendY;

    public AnimatorVector2InputConsumer(Animator animator, string blendX, string blendY)
    {
        this.animator = animator;
        this.blendX = blendX;
        this.blendY = blendY;
    }

    public void Consume(Vector2 input)
    {
        animator.SetFloat(blendX, input.x);
        animator.SetFloat(blendY, input.y);
    }
}