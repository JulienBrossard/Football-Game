using UnityEngine;

[RequireComponent(typeof(Rigidbody), typeof(FootballMasterData))]
public class Movement : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    private FootballMasterDataController data;
    private float speed;
    private Stamina stamina;

    private void Awake()
    {
        data = GetComponent<FootballMasterData>().controller;
        speed = data.speed;
        stamina = GetComponent<Stamina>();
    }

    public void VerticalMovement(int direction)
    {
        rb.velocity = new Vector3(speed * direction,rb.velocity.y,rb.velocity.z);
    }

    public void HorizontalMovement(int direction)
    {
        rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, direction * speed);
    }

    public void Sprint()
    {
        if (stamina.stamina>0)
        {
            speed *= 1.5f;
        }
    }

    public void ResetSpeed()
    {
        speed = data.speed;
    }
}
