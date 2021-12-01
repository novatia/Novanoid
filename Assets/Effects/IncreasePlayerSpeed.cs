using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncreasePlayerSpeed : MonoBehaviour, IEffect
{
    public float Duration = 5;
    public float PlayerSpeed = 4;

    private PlayerController m_PlayerController;
    public void Drop(Vector3 position)
    {
        //Generate falling game object 
        GameObject instance = GameObject.Instantiate(Resources.Load("IncreasePlayerSpeed", typeof(GameObject))) as GameObject;
        instance.transform.position = position;
    }

    IEnumerator DestroyEffect()
    {
        yield return new WaitForSeconds(Duration);
        m_PlayerController.ResetSpeed();
        Destroy(gameObject);
        yield return null;
    }

    public void GetEffect()
    {
        m_PlayerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        m_PlayerController.SetSpeed(PlayerSpeed);
        StartCoroutine("DestroyEffect");
    }
}
