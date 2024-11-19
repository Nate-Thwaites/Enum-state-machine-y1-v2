using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public GameObject Enemy;
    public float TimeToLive = 5f;
    private void Start()
    {
        Destroy(gameObject, TimeToLive);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {

            Destroy(gameObject);
        }
        // Start is called before the first frame update
    }
}


 