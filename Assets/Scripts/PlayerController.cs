using UnityEngine;
using UnityEngine.Serialization;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float torqueAmount = 15f;
    [SerializeField] private float baseSpeed = 20f;
    [SerializeField] private float boostSpeed = 30f;
    private Rigidbody2D _rb2d;
    private SurfaceEffector2D _surfaceEffector2D;
    private bool canMove = true;
    
    
    // Start is called before the first frame update
    void Start()
    {
        _rb2d = GetComponent<Rigidbody2D>();
        _surfaceEffector2D = FindObjectOfType<SurfaceEffector2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (canMove)
        {
            RotatePlayer();
            RespondToBoost();
        }
        
    }

    public void DisableControls()
    {
        canMove = false;
    } 

    void RespondToBoost()
    {
        _surfaceEffector2D.speed = Input.GetKey(KeyCode.W) ? boostSpeed : baseSpeed;
    }

    void RotatePlayer()
    {
        if(Input.GetKey(KeyCode.A))
        {
            _rb2d.AddTorque(torqueAmount);
        }
        else if(Input.GetKey(KeyCode.D))
        {
            _rb2d.AddTorque(-torqueAmount);
        }
    }
}
