using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float torqueAmount = 1f;
    Rigidbody2D _rb2d;
    // Start is called before the first frame update
    void Start()
    {
        _rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.LeftArrow))
        {
            _rb2d.AddTorque(torqueAmount);
        }
        else if(Input.GetKey(KeyCode.RightArrow))
        {
            _rb2d.AddTorque(-torqueAmount);
        }
    }
}
