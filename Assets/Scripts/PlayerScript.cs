using UnityEngine;

public enum States // used by all logic
{
    None,
    Idle,
    Walk,
    Jump,
    Dead,
    Hit,
};

public class PlayerScript : MonoBehaviour
{
    States state;

    public GameObject weapon;

    Rigidbody rb;
    bool grounded;
    bool dead;
    GameObject Player;

    public Transform shootPoint;

    public static int health;
    int moveDirection = 1;
    bool hit;
    // Start is called before the first frame update
    void Start()
    {
        state = States.Idle;
        rb = GetComponent<Rigidbody>();
        health = 10;
    }

    // Update is called once per frame
    void Update()
    {
        DoLogic();
        ShootWeapon();
    }

    void FixedUpdate()
    {
        grounded=false;
        
        hit = false;
        
    }


    void DoLogic()
    {
        if( state == States.Idle )
        {
            PlayerIdle();
        }

        if( state == States.Jump )
        {
            PlayerJumping();
        }

        if( state == States.Walk )
        {
            PlayerWalk();
        }

        if( state == States.Hit)
        {
            PlayerHit();
        }
    }


    void PlayerIdle()
    {
        if( Input.GetKeyDown(KeyCode.Space))
        {
            // simulate jump
            state = States.Jump;
            rb.velocity = new Vector3( 0,10,0);
        }

        if( Input.GetKey("right"))
        {
            transform.Rotate( 0, 0.5f, 0, Space.Self );

        }
        if( Input.GetKey("left"))
        {
            transform.Rotate( 0,-0.5f, 0, Space.Self );
        }

        if( Input.GetKey("up"))
        {
            state = States.Walk;
           
        }
    }

    void PlayerJumping()
    {
        // player is jumping, check for hitting the ground
        if( grounded == true )
        {
            //player has landed on floor
            state = States.Idle;
        }
    }

    void PlayerWalk()
    {
        rb.velocity = Vector3.ClampMagnitude(rb.velocity, 5f);

        //magnitude = the player's speed
        float magnitude = rb.velocity.magnitude;



        if (Input.GetKey("up") == true)
        {
            rb.AddForce(transform.forward * 5f);
        }

        if (Input.GetKey("up") == false)
        {
            if (magnitude < 0.1f)
            {
                rb.velocity = Vector3.zero;
                state = States.Idle;
            }

        }
       


            
            

        if (Input.GetKey("right"))
        {
            transform.Rotate(0, 0.5f, 0, Space.Self);
            

        }
        if (Input.GetKey("left"))
        {
            transform.Rotate(0, -0.5f, 0, Space.Self);
        }
    }

    void PlayerHit()
    {
        print("Player is hit");
    }

    public void SetPlayerHit()
    {
        state = States.Jump;
        rb.velocity = new Vector3(6, 6, 0);
    }

    void OnCollisionEnter( Collision col )
    {
        if( col.gameObject.tag == "Floor")
        {
            grounded=true;
            print("landed!");
        }
    }

   


    private void OnGUI()
    {
        //debug text
        string text = "Left/Right arrows = Rotate\nSpace = Jump\nUp Arrow = Forward\nCurrent state = " + state + "\nPlayer Health = " + health;

        // define debug text area
        GUILayout.BeginArea(new Rect(10f, 420f, 1600f, 1600f));
        GUILayout.Label($"<size=16>{text}</size>");
        GUILayout.EndArea();
    }

    void ShootWeapon()
    {


        if (Input.GetButtonDown("Fire1"))
        {
            // Instantiate the bullet at the position and rotation of the player
            GameObject clone;
            clone = Instantiate(weapon, transform.position, transform.rotation);




            // for 3D, get the rigidbody component
            Rigidbody rb = clone.GetComponent<Rigidbody>();




            // set the velocity
            rb.velocity = transform.forward * 15;


            // set the position close to the player
            rb.transform.position = shootPoint.position;

            
        }

    }

}
