using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public static Vector3 move;
    public float speed;
    CharacterController contr;
    public Camera mainCam;
    public Transform cameraLookAtTarget;
    public Transform PlayerTransform;

    public Animator animator;
    public PlayerMain playerMain;
    public Transform spawnTransform;
    private void Start()
    {
        contr = GetComponent<CharacterController>();
    }
    // Update is called once per frame
    void Update()
    {
        Movement();
    }
    private void LookAtCamTarget()
    {
            Vector3 m = Input.mousePosition;
            m = new Vector3(m.x, m.y, transform.position.y);
            Vector3 p = mainCam.ScreenToWorldPoint(m);
            Camera cami = mainCam;
            Ray raycast = cami.ScreenPointToRay(Input.mousePosition);
            RaycastHit hito;
            if (Physics.Raycast(raycast, out hito))
            {
                cameraLookAtTarget.transform.position = new Vector3(hito.point.x,0.5f,hito.point.z); //hito.point;
                Vector3 target = new Vector3(cameraLookAtTarget.position.x, transform.position.y, cameraLookAtTarget.position.z);
                PlayerTransform.LookAt(target);//new Vector3(cameraLookAtTarget.position.x,transform.position.y,cameraLookAtTarget.position.z));
            }

    }
    private void LookAtObjectTarget()
    {
            Vector3 target = new Vector3(cameraLookAtTarget.position.x, transform.position.y, cameraLookAtTarget.position.z);
            PlayerTransform.LookAt(target);//new Vector3(cameraLookAtTarget.position.x,transform.position.y,cameraLookAtTarget.position.z));
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
                animator.SetBool("Run", true);
            }
            else
            {
                way *= verticalMove;
                animator.SetBool("Run",true);
            }
        }
        else
        {
            if (horizontalMove != 0)
            {
                way = Quaternion.Euler(0, 90 * horizontalMove, 0) * way;
                animator.SetBool("Run", true);
            }
            else
            {
                way = new Vector3();
                animator.SetBool("Run", false);
            }
        }
        speed = playerMain.speed/100;
        move = way * speed;
        contr.Move(move);
        Vector3 direction = Vector3.RotateTowards(PlayerTransform.forward,way,Time.deltaTime*30f,0.0f);
        PlayerTransform.rotation = Quaternion.LookRotation(direction); 

        Vector3 pos = transform.position;
        transform.position = pos;
    }
}
