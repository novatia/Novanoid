using System.Collections;
using UnityEngine;

public class TripleBall : MonoBehaviour, IEffect
{
    public void Drop(Vector3 position)
    {
        //Generate falling game object 
        GameObject instance = GameObject.Instantiate(Resources.Load("TripleBall", typeof(GameObject))) as GameObject;
        instance.transform.position = position;
    }

    public void GetEffect()
    {
        Vector3 position;
        Vector3 direction;
        GameObject ball = GameObject.FindGameObjectWithTag("Ball");
        position = ball.transform.position;
        direction = ball.transform.forward;

        GameObject instance1 = GameObject.Instantiate(Resources.Load("Ball", typeof(GameObject)),position,Quaternion.identity) as GameObject;
        GameObject instance2 = GameObject.Instantiate(Resources.Load("Ball", typeof(GameObject)), position, Quaternion.identity) as GameObject;

        Vector3 dir1 = Quaternion.AngleAxis(-45f, Vector3.up) * direction;
        Vector3 dir2 = Quaternion.AngleAxis(45f, Vector3.up) * direction;

        instance1.GetComponent<Rigidbody>().AddForce(dir1);
        instance2.GetComponent<Rigidbody>().AddForce(dir2);
    }
}
