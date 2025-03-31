using UnityEngine;

public class AllPlatformController : MonoBehaviour
{
    private float downspeed = 1f;
    [SerializeField]public float downSpeed 
    {
        get {return downspeed; }
        set {downspeed = Mathf.Clamp(value, 0.7f, 2f);}
    }
    [SerializeField]private float belowLimit;
    void Start()
    {
        downSpeed = Random.Range(0.7f,1.3f);
    }

    // Update is called once per frame
    void Update()
    {
        
        MovingDown(downSpeed);
        DestroyOnOutOfLimit();
    }

    public virtual void MovingDown(float dowingspeed = 1f)
    {
        transform.Translate(Vector3.down * dowingspeed * Time.deltaTime);
    }

    public virtual void DestroyOnOutOfLimit()
    {
        if (transform.position.y < belowLimit)
        {
            Destroy(gameObject);
        }
    }
}
