using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour
{
    public Vector3 StartPosition = new Vector3(-1,1,0);
    public Vector3 Direction;
    [Range(1.1f,3)]
    public float Speed = 1.1f;

    private Rigidbody2D m_RigidBody;

    void Start()
    {
        m_RigidBody = GetComponent<Rigidbody2D>();
        ResetComponent();
    }

    private void Update()
    {
        Vector2 v = m_RigidBody.velocity;
        v = v.normalized;
        v *= Speed;
        m_RigidBody.velocity = v;
    }

    public void ResetComponent()
    {
        transform.position = StartPosition;
        m_RigidBody.velocity = Direction * Speed;
    }
}