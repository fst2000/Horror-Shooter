public interface ICreature
{
    void Idle();
    void Move();
    void Attack();
    void Wound(float damage);
    void Die();
}