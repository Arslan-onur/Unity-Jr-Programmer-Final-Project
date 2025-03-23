using System.Collections;
using UnityEngine;

public class Platform1Controller : MonoBehaviour
{
    Rigidbody platform1Rb;
    private float waitForFall = 2f;
    private float shakeInterval = 0.1f;
    private int shakeTimes = 50;

    private float shakeOnX = 4f;
    private float shakeOnY = 4f;

    [SerializeField]private float downSpeed = 1f;
    void Start()
    {
        platform1Rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * downSpeed * Time.deltaTime);
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            StartCoroutine("WaitAndFall");
            
        }
    }

    IEnumerator WaitAndFall()
    {
        StartCoroutine("ShakeBeforeFall");
        yield return new WaitForSeconds(waitForFall);
        platform1Rb.isKinematic = false;
        platform1Rb.useGravity = true;
    }

    IEnumerator ShakeBeforeFall()
    {
        Vector3 shake = new Vector3 (shakeOnX,shakeOnY, 0.0f);
        for (int i = 0; i<=shakeTimes; i++ )
        {
            transform.Translate((shake*i/10) * Time.deltaTime);
            yield return new WaitForSeconds(shakeInterval);
            transform.Translate((-shake*i/10) * Time.deltaTime);
            yield return new WaitForSeconds(shakeInterval );
        }

    }
}
