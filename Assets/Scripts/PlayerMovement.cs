using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public static Vector3 move;
    public float speed;
    CharacterController contr;
    private void Start()
    {
        contr = GetComponent<CharacterController>();
    }
    // Update is called once per frame
    void Update()
    {
        Movement();
    }
    private void Movement()
    {
        sbyte verticalMove = 0;
        sbyte horizontalMove = 0;

        Vector3 way = new Vector3(1, 0, 1);

        if (Input.GetKey(KeyCode.W))
        {
            verticalMove++;
        }

        if (Input.GetKey(KeyCode.S))
        {
            verticalMove--;
        }

        if (Input.GetKey(KeyCode.A))
        {
            horizontalMove--;
        }

        if (Input.GetKey(KeyCode.D))
        {
            horizontalMove++;
        }



        if (verticalMove != 0)
        {
            if (horizontalMove != 0)
            {
                way *= verticalMove;
                way = Quaternion.Euler(0, 45 * horizontalMove * verticalMove, 0) * way;
            }
            else
            {
                way *= verticalMove;
            }
        }
        else
        {
            if (horizontalMove != 0)
            {
                way = Quaternion.Euler(0, 90 * horizontalMove, 0) * way;
            }
            else
            {
                way = new Vector3();
            }
        }

        move = way * speed;
        contr.Move(move);

        Vector3 pos = transform.position;
        transform.position = pos;
    }
}
