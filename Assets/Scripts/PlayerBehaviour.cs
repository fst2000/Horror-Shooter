using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerBehaviour : MonoBehaviour
{
    [SerializeField] Transform gunTransform;
    [SerializeField] Player player;
    void Start()
    {
        player = new Player(gameObject);
    }
    void Update()
    {
        player.Move();
        player.Attack();
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(gunTransform.position, gunTransform.position + gunTransform.rotation * Vector3.down * 1000f);
    }
}
