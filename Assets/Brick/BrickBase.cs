using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class BrickBase : MonoBehaviour
{
    UnityEvent m_BrickBroken;
    public AudioClip Destroyed;
    public AudioClip Hit;

    private AudioSource m_AudioSource;

    private IEffect m_Effect;

    private GameObject m_Object;

    private void Start()
    {
        m_Effect = EffectFactory.GetEffect();
        m_AudioSource = GetComponent<AudioSource>();
        m_Object = gameObject;
    }

    public void BindEvent(UnityAction action)
    {
        m_BrickBroken = new UnityEvent();
        m_BrickBroken.AddListener(action);
    }

    private IEnumerator DestroyBrick()
    {

        m_AudioSource.clip = Destroyed;
        m_AudioSource.Play();

        m_BrickBroken.Invoke();
        
        if (m_Effect != null)
            m_Effect.Drop(m_Object.transform.position);

        while ( m_AudioSource.isPlaying )
        {
            yield return new WaitForEndOfFrame();        
        }

        //yield return new WaitForSeconds(0.5f);


        Destroy(gameObject);

        yield return null;
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ball")
        {
            StartCoroutine("DestroyBrick");
        }
        else {
            //m_AudioSource.clip = Hit;
            //m_AudioSource.Play();
        }
    }
}