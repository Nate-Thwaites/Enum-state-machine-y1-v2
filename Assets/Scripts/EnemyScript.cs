using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Threading;
using System.Threading.Tasks;


public class EnemyScript : MonoBehaviour
{
    Rigidbody rb;
    //public static int enemyHealth;
    bool dead;
    bool hit;
    GameObject Player;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        hit = false;

    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            hit = true;
            rb.velocity = new Vector3(6, 6, 0);
            PlayerScript.health = PlayerScript.health - 2;

            collision.gameObject.GetComponent<PlayerScript>().SetPlayerHit();

            /*if (hit == true)
            {
                Task.Delay(1000);
                state = States.Walk;
                hit = false;
            }*/



        }

        if (PlayerScript.health <= 0)
        {
            SceneManager.LoadScene("Demo");
            dead = true;
        }





    }
}

