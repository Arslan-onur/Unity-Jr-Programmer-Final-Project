using UnityEngine;

public class CubeWireframe : MonoBehaviour
{
    PlayerController playerController;
    [SerializeField] private int playerSpeedMultiplier = 10;
    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            playerController = collision.gameObject.GetComponent<PlayerController>();
            playerController.playerSpeed *= playerSpeedMultiplier;
        }
    }

    void OnCollisionExit(Collision collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
        playerController = collision.gameObject.GetComponent<PlayerController>();
        playerController.playerSpeed /= playerSpeedMultiplier;
        }
    }
}