using UnityEngine;

public class AnimatorInputConsumer : IInputConsumer
{
    Animator animator;
    string blendX;
    string blendY;

    public AnimatorInputConsumer(Animator animator, string blendX, string blendY)
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