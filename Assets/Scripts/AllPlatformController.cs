using UnityEngine;

public class AllPlatformController : MonoBehaviour
{
    [SerializeField]private float downSpeed = 1f;
    [SerializeField]private float belowLimit;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * downSpeed * Time.deltaTime);
        DestroyOnOutOfLimit();
    }

    void DestroyOnOutOfLimit()
    {
        if (transform.position.y < belowLimit)
        {
            Destroy(gameObject);
        }
    }
}
