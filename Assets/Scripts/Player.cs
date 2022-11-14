using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class Player : ICreature
{
    Animator animator;
    NavMeshAgent navMeshAgent;
    Transform transform;
    PlayerInput playerInput;
    float playerRotation;
    float rotationSpeed;
    float moveSpeed;
    public Player(GameObject gameObject)
    {
        this.animator = gameObject.GetComponent<Animator>();
        this.navMeshAgent = gameObject.GetComponent<NavMeshAgent>();
        this.transform = gameObject.transform;
        this.playerInput = new PlayerInput();
    }
    public void Attack()
    {
        animator.SetBool("isAttacking", true);
    }

    public void Die()
    {
        throw new System.NotImplementedException();
    }

    public void Idle()
    {
        throw new System.NotImplementedException();
    }

    public void Move()
    {
        playerRotation += playerInput.MouseX * rotationSpeed * Time.deltaTime;
        transform.rotation = Quaternion.AngleAxis(playerRotation, Vector3.up);
        Vector3 velocity = navMeshAgent.velocity;
        navMeshAgent.velocity = playerInput.WalkInput * moveSpeed;
        animator.SetFloat("BlendMoveX", playerInput.MoveHorizontal);
        animator.SetFloat("BlendMoveY", playerInput.MoveVertical);
    }
}
