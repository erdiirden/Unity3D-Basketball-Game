using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class topkontrol : MonoBehaviour
{
    public Joystick joystick;
    Camera kamera;
    //atýþ------------------------------------------------
    Vector2 startPos, endPos, direction;
    float touchTimeStart, touchTimeFinish, timeInterval;
    [SerializeField]
    float throwForceInXandY = 1f;
    [SerializeField]
    float throwForceInZ = 50f;
    Rigidbody rb;
    //atýþ------------------------------------------------
    void Start()
    {
        kamera = GameObject.Find("Main Camera").GetComponent<Camera>();
        rb = GetComponent<Rigidbody>();
        joystick = FindObjectOfType<Joystick>();
    }
    
    void FixedUpdate()
    {
        if (Input.touchCount >0)
        {
            Touch parmak = Input.GetTouch(0);
            RaycastHit dokunulanNesne;
            if(Physics.Raycast(kamera.ScreenPointToRay(parmak.position),out dokunulanNesne))
            {
                if (dokunulanNesne.collider.gameObject.tag == "top")
                {
                    if (Input.GetTouch(0).phase == TouchPhase.Began)
                    {
                        touchTimeStart = Time.time;
                        startPos = Input.GetTouch(0).position;
                    }

                    if (Input.GetTouch(0).phase == TouchPhase.Ended)
                    {

                        touchTimeFinish = Time.time;

                        timeInterval = touchTimeFinish - touchTimeStart;

                        endPos = Input.GetTouch(0).position;

                        direction = startPos - endPos;

                        rb.isKinematic = false;
                        rb.AddForce(-direction.x * throwForceInXandY, -direction.y * throwForceInXandY, throwForceInZ / timeInterval);

                        // Destroy ball in 4 seconds
                        //Destroy (gameObject, 3f);

                    }
                }
                else
                {
                    rb.velocity = new Vector3(joystick.Horizontal * 4f, rb.velocity.y, joystick.Vertical * 4f);
                    rb.angularVelocity = Vector3.forward * 2f;
                }
            }
        }
    }
}
