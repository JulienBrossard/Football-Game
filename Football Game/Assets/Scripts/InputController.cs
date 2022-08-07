using System;
using UnityEngine;

public class InputController : MonoBehaviour
{
    [SerializeField] private GameObject player1;
    private Movement player1Movement;
    private Stamina player1Stamina;
    
    KeyCode leftMovement = KeyCode.Q;
    KeyCode rightMovement = KeyCode.D;
    KeyCode upMovement = KeyCode.Z;
    KeyCode downMovement = KeyCode.S;
    private KeyCode sprint = KeyCode.LeftShift;

    private void Awake()
    {
        player1Movement = player1.GetComponent<Movement>();
        player1Stamina = player1.GetComponent<Stamina>();
    }

    private void FixedUpdate()
    {
        if (Input.GetKey(leftMovement) && !Input.GetKey(rightMovement))
        {
            player1Movement.HorizontalMovement(-1);
        }

        else if (Input.GetKey(rightMovement) && !Input.GetKey(leftMovement))
        {
            player1Movement.HorizontalMovement(1);
        }

        if (Input.GetKey(upMovement) && !Input.GetKey(downMovement))
        {
            player1Movement.VerticalMovement(-1);
        }
        
        else if (Input.GetKey(downMovement) && !Input.GetKey(upMovement))
        {
            player1Movement.VerticalMovement(1);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(sprint))
        {
            player1Movement.Sprint();
        }
        else if(Input.GetKey(sprint))
        {
            player1Stamina.UseStamina(0.1f);
            if (player1Stamina.stamina<=0)
            {
                player1Movement.ResetSpeed();
            }
        }
        else if (Input.GetKeyUp(sprint))
        {
            player1Movement.ResetSpeed();
        }
    }
}
