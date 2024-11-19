using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform player;

    // Update is called once per frame
    void Update()
    {
        transform.position = player.transform.position + new Vector3(0, 1, 0);

        if (Input.GetKey("right"))
        {
            transform.Rotate(0, 0.5f, 0, Space.Self);
        }

        if (Input.GetKey("left"))
        {
            transform.Rotate(0, -0.5f, 0, Space.Self);
        }
    }


}