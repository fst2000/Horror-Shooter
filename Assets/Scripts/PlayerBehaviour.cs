using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerBehaviour : MonoBehaviour
{
    [SerializeField] float moveSpeed = 4f;
    [SerializeField] Transform gunTransform;
    [SerializeField] float rotationSpeed = 1f;
    [SerializeField] float radius;
    [SerializeField] float height;
    Player player;
    float playerRotation;
    void Start()
    {
        player = new Player(gameObject);
    }
    void Update()
    {
        player.Move();

    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(gunTransform.position, gunTransform.position + gunTransform.rotation * Vector3.down * 1000f);
    }
}
