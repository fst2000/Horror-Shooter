using UnityEngine;
public class AnimatorBoolInputConsumer : IInputConsumer<bool>
{
    Animator animator;
    string onTrue;
    string onFalse;
    bool tempInput;

    public AnimatorBoolInputConsumer(Animator animator, string onTrue, string onFalse)
    {
        this.animator = animator;
        this.onTrue = onTrue;
        this.onFalse = onFalse;
    }

    public void Consume(bool input)
    {
        if(tempInput != input)
        {
            animator.CrossFade(input? onTrue : onFalse, 0.05f);
            tempInput = input;
        }
    }
}