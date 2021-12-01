using System.Collections;
using UnityEngine;

public class SlowSpeed : MonoBehaviour, IEffect
{
    public float Duration = 10f;
    public float BallSpeed = 5;

    public void Drop(Vector3 position)
    {
        //Generate falling game object 
        GameObject instance = GameObject.Instantiate(Resources.Load("SlowSpeed", typeof(GameObject))) as GameObject;
        instance.transform.position = position;
    }

    IEnumerator DestroyEffect() {
        yield return new WaitForSeconds(Duration);
        GameObject.FindGameObjectWithTag("Ball").GetComponent<BallScript>().ResetSpeed();
        Destroy(gameObject);
        yield return null;
    }

    public void GetEffect()
    {
        //Get ball, set mass, start coroutine to reset previous values. and destroy
        GameObject.FindGameObjectWithTag("Ball").GetComponent<BallScript>().SetSpeed (BallSpeed);
        StartCoroutine("DestroyEffect");
    }
}
