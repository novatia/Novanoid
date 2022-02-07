using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour
{
    public Vector3 StartPosition = new Vector3(-1,1,0);
    public Vector3 Direction;

    private Vector3 m_PlayerDirection;

    [Range(1.1f,3)]
    public float Speed = 1.1f;

    public float PlayerGravity = 2f;

    private float m_CurrentSpeed;

    private Rigidbody2D m_RigidBody;

    private Vector3 m_HitPosition;
    private Vector3 m_HitDirection;
    private Vector3 m_NewDirection;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Brick")
        {

        }


        if (collision.gameObject.tag == "Border" || collision.gameObject.tag == "Ceil")
        {
            //float speed = m_RigidBody.velocity.magnitude;
            //Vector3 direction = Vector3.Reflect(m_RigidBody.velocity.normalized, collision.contacts[0].normal);
            //m_RigidBody.velocity = direction * speed;
        }

        if (collision.gameObject.tag == "Player") 
        {
            GameObject player = collision.gameObject;
            PlayerController player_controller = player.GetComponent<PlayerController>();

            m_PlayerDirection = Vector3.zero;

            if (player_controller.GoingLeft)
                m_PlayerDirection = Vector3.left;

            if (player_controller.GoingRight)
                m_PlayerDirection = Vector3.right;

            float distance = ( transform.position - player.transform.position).magnitude;

            m_HitPosition = collision.contacts[0].point;
            m_HitDirection = m_RigidBody.velocity.normalized;

            m_NewDirection = (m_HitDirection + Vector3.up * distance * PlayerGravity).normalized;
            m_NewDirection = (m_NewDirection + m_PlayerDirection*PlayerGravity).normalized;

            
            m_RigidBody.velocity = m_NewDirection*Speed;


        }
    }

    internal void ResetSpeed()
    {
        m_CurrentSpeed = Speed;
    }

    void Start()
    {
        m_RigidBody = GetComponent<Rigidbody2D>();
        //ResetComponent();
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

#if UNITY_EDITOR

  
    public void OnDrawGizmos()
    {
        GizmoUtility.DrawArrow(transform.position, transform.up, Color.yellow);


        if (m_RigidBody!=null)
            GizmoUtility.DrawArrow(transform.position, m_RigidBody.velocity,Color.red);

        if (m_HitPosition != null)
            GizmoUtility.DrawArrow(m_HitPosition, m_HitDirection, Color.green);

        if (m_HitPosition != null)
            GizmoUtility.DrawArrow(m_HitPosition, m_NewDirection, Color.cyan);

    }
#endif
}