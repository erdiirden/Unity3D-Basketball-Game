using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Collider))]
public class dokunarakAtis : MonoBehaviour
{
    private Vector3 dokunmaAni;
    private Vector3 birakmaAni;

    private Rigidbody rb;

    private bool isShoot;
    private float guc = 1f;
    private float sky = 1.2f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    public void Update()
    {
        Vector3 atis = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        if (Input.touchCount > 0)
        {
            Touch parmak = Input.GetTouch(0);
            if (parmak.phase == TouchPhase.Ended)
            {
                if (parmak.deltaPosition.y > 20.0f)
                {
                    if (isShoot)
                        return;

                    rb.AddForce(new Vector3(atis.x * guc, atis.y * sky, atis.y * guc));
                    isShoot = true; 
                }
                
            }
        }
    }
}