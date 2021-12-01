using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour
{
    public Vector3 StartPosition = new Vector3(-1,1,0);
    public Vector3 Direction;
    [Range(1.1f,3)]
    public float Speed = 1.1f;

    public float BorderForce = 2f;

    private float m_CurrentSpeed;

    private Rigidbody2D m_RigidBody;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Border" || collision.gameObject.tag == "Ceil" || collision.gameObject.tag == "Player" || collision.gameObject.tag == "Brick")
        {
            float speed = m_RigidBody.velocity.magnitude;
            Vector3 direction = Vector3.Reflect(m_RigidBody.velocity.normalized, collision.contacts[0].normal);
            m_RigidBody.velocity = direction * speed;
        }
    }

    internal void ResetSpeed()
    {
        m_CurrentSpeed = Speed;
    }

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

    public void SetSpeed(float ballSpeed)
    {
        m_CurrentSpeed = ballSpeed;
    }

    public void ResetComponent()
    {
        transform.position = StartPosition;
        m_RigidBody.velocity = Direction * Speed;
        ResetSpeed();
    }
}