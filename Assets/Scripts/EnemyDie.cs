using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDie : MonoBehaviour
{
    public GameObject Bullet;
    public int enemyHealth = 10;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            
            
            enemyHealth = enemyHealth - 2;
            print(enemyHealth);
            

            if (enemyHealth <= 0)
            {
                Destroy(gameObject);
               
            }
        }
    }
}



