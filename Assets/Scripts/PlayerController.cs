using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float playerSpeed = 10;
    private float playerJumpForce =10;
    private bool onGround;
    Rigidbody playerRb;
    void Start()
    {
        
        playerRb = GetComponent<Rigidbody>();
        onGround = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && onGround)
        {
            playerRb.AddForce(Vector3.up * playerJumpForce, ForceMode.Impulse);
            onGround= false;
        }
    }

    void FixedUpdate()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        playerRb.AddForce(Vector3.right * playerSpeed * horizontalInput);
 

    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Platform"))
        {
            onGround = true;
        }
    }
}
