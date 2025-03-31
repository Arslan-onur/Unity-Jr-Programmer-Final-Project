using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float playerSpeed = 10;
    private float playerJumpForce =10;
    private bool onGround;
    Rigidbody playerRb;

    [SerializeField] float playerXlimit;
    private float backLimitForce = 5f;

    public bool isGameOver = false;
    void Start()
    {
        
        playerRb = GetComponent<Rigidbody>();
        onGround = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < -6)
        {
            isGameOver = true;
            Destroy(gameObject);
            GameOver();
        }
        
        if (Input.GetKeyDown(KeyCode.Space) && onGround && !isGameOver)
        {
            playerRb.AddForce(Vector3.up * playerJumpForce, ForceMode.Impulse);
            onGround= false;
        }
        StayOnLimits();
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

    private void StayOnLimits()
    {
        if (transform.position.x > playerXlimit)
        {
            gameObject.transform.position = new Vector3(playerXlimit, transform.position.y, transform.position.z);
            playerRb.AddForce(Vector3.left * backLimitForce,ForceMode.Impulse);
        }
        else if (transform.position.x < -playerXlimit)
        {
            gameObject.transform.position = new Vector3(-playerXlimit, transform.position.y, transform.position.z);
            playerRb.AddForce(-Vector3.left * backLimitForce,ForceMode.Impulse);
        }
    }

    private void GameOver()
    {
        GameManager gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        gameManager.GameOverText.SetActive(true);
        gameManager.restartButton.SetActive(true);
        gameManager.mainMenuButton.SetActive(true);

    }
}
