using UnityEngine;

public class Platform2Controller : MonoBehaviour
{
    [SerializeField] float lineerDampingOnPlatform; 
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Rigidbody playerRb = collision.gameObject.GetComponent<Rigidbody>();
            playerRb.linearDamping = lineerDampingOnPlatform;
        }
    }
    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Rigidbody playerRb = collision.gameObject.GetComponent<Rigidbody>();
            playerRb.linearDamping = 0;
        }
    }
}
