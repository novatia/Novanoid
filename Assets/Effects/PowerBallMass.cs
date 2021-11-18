using System.Collections;
using UnityEngine;

public class PowerBallMass : MonoBehaviour, IEffect
{
    public float Duration = 10f;

    public void Drop(Vector3 position)
    {
        //Generate falling game object 
        GameObject instance = GameObject.Instantiate(Resources.Load("PowerBallMass", typeof(GameObject))) as GameObject;
        instance.transform.position = position;
    }

    IEnumerator DestroyEffect() {
        yield return new WaitForSeconds(Duration);
        GameObject.FindGameObjectWithTag("Ball").GetComponent<Rigidbody2D>().mass = 1;
        Destroy(gameObject);
        yield return null;
    }

    public void GetEffect()
    {
        //Get ball, set mass, start coroutine to reset previous values. and destroy
     
        GameObject.FindGameObjectWithTag("Ball").GetComponent<Rigidbody2D>().mass = 8;

        StartCoroutine("DestroyEffect");
    }
}
