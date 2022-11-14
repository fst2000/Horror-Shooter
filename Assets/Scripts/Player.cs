using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

[System.Serializable] public class Player : ICreature
{
    Animator animator;
    NavMeshAgent navMeshAgent;
    Transform transform;
    PlayerInput playerInput;
    float playerRotation;
    [SerializeField] float rotationSpeed = 200f;
    [SerializeField] float moveSpeed = 2f;
    int health = 100;
    enum stateEnum {Moving, Attacking, Wounded, Dead};
    stateEnum playerState;
    public Player(GameObject gameObject)
    {
        this.animator = gameObject.GetComponent<Animator>();
        this.navMeshAgent = gameObject.GetComponent<NavMeshAgent>();
        this.transform = gameObject.transform;
        this.playerInput = new PlayerInput();
    }
    public void Attack()
    {
        if (playerInput.IsAim)
        {
            animator.SetBool("IsAttacking", true);
            playerState = stateEnum.Attacking;
        }
        else
        {
            animator.SetBool("IsAttacking", false);
            playerState = stateEnum.Moving;
        }
    }
    public void Wound(float damage)
    {
        health -= (int)damage;
        playerState = stateEnum.Wounded;
    }
    public void Die()
    {
        if (health <= 0)
        {
            playerState = stateEnum.Dead;
        }
    }

    public void Idle()
    {
        throw new System.NotImplementedException();
    }

    public void Move()
    {
        playerRotation += playerInput.MouseX * rotationSpeed * Time.deltaTime;
        transform.rotation = Quaternion.AngleAxis(playerRotation, Vector3.up);

        if (playerState == stateEnum.Moving)
        {
            Vector3 velocity = navMeshAgent.velocity;
            navMeshAgent.velocity = playerInput.WalkInput * moveSpeed;
            animator.SetFloat("BlendMoveX", playerInput.MoveHorizontal);
            animator.SetFloat("BlendMoveY", playerInput.MoveVertical);
        }
    }
}
