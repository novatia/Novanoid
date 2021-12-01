using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private bool m_LeftTrigger;
    private bool m_RightTrigger;
    public float Speed = 2;

    private float m_CurrentSpeed = 2;

    public Vector3 StartPosition=Vector3.zero;
    public Vector3 LeftBound;
    public Vector3 RightBound;
    private AudioSource m_AudioSource;

    private void Start()
    {
        m_AudioSource = GetComponent<AudioSource>();
        ResetComponent();
    }

    public void ResetComponent() {
        transform.position = StartPosition;
        ResetSpeed();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        string tag = collision.gameObject.tag;
        if (tag == "Ball")
        {
            m_AudioSource.Play();
            //collision.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector3.);
        }

        if (tag == "Effect")
        {
            Destroy(collision.gameObject.GetComponent<Rigidbody>());
            Destroy(collision.gameObject.GetComponent<SpriteRenderer>());

            collision.gameObject.GetComponent<IEffect>().GetEffect();
        }

        if (tag=="Brick")
        {
            collision.gameObject.GetComponent<BrickBase>().StartCoroutine("DestroyBrick");
        }
    }

    public void ResetSpeed()
    {
        m_CurrentSpeed = Speed;
    }

    public void SetSpeed(float speed)
    {
        m_CurrentSpeed = speed;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
            m_LeftTrigger = true;

        if (Input.GetKeyDown(KeyCode.RightArrow))
            m_RightTrigger = true;

        if (Input.GetKeyUp(KeyCode.LeftArrow))
            m_LeftTrigger = false;

        if (Input.GetKeyUp(KeyCode.RightArrow))
            m_RightTrigger = false;


        if (m_LeftTrigger)
            if (LeftBound.x < transform.position.x)
            transform.Translate(Speed * Vector3.left * Time.deltaTime);

        if (m_RightTrigger)
            if (RightBound.x > transform.position.x)
                transform.Translate(Speed * Vector3.right * Time.deltaTime);

    }
}
