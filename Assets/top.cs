using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class top : MonoBehaviour
{
    Rigidbody rigi;
    bool sol;
    bool sag;
    bool ileri;
    bool geri;
    float hiz = 0.2f;
    float topDondur = 6.0f;
    public Rigidbody ball;
    public float shootPower = 30f;

    void Start()
    {
        rigi = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //Transform.Translate(0, 0, hiz * Time.deltaTime); sürekli ileri gitme
        Vector3 ileri_git = new Vector3(transform.position.x, transform.position.y, 42.0f);
        Vector3 geri_git = new Vector3(transform.position.x, transform.position.y, -1.0f);
        Vector3 sag_git = new Vector3(7.8f, transform.position.y, transform.position.z);
        Vector3 sol_git = new Vector3(-9.0f, transform.position.y, transform.position.z);
        if (Input.touchCount > 0)
        {
            Touch parmak = Input.GetTouch(0);

            //ileri-geri
            if (parmak.deltaPosition.y > 20.0f)
            {
                ileri = true;
                geri = false;
            }
            if (parmak.deltaPosition.y < -20.0f)
            {
                ileri = false;
                geri = true;
            }
            if (ileri == true)
            {
                transform.position = Vector3.Lerp(transform.position, ileri_git, hiz * 0.08f);
                this.transform.Rotate(Vector3.up, topDondur);
            }
            if (geri == true)
            {
                transform.position = Vector3.Lerp(transform.position, geri_git, hiz * 0.08f);
                this.transform.Rotate(Vector3.down, -topDondur);
            }

            //Sag 7.8
            //sol -9
            //ileri 42
            //geri -1
        }
        if (Input.GetMouseButtonUp(0))
        {
            ball.velocity = transform.forward * shootPower;
        }
    }
}
