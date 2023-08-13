using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BasketballController : MonoBehaviour {

    public float MoveSpeed = 2;
    public Transform Ball;
    public Transform PosDribble;
    public Transform PosOverHead;
    public Transform Arms;
    public Transform Target;

    // variables
    private bool IsBallInHands = true;
    private bool IsBallFlying = false;
    private float T = 0;
    public static int skorCek;
    //bool oyunBittiMi = false;

    // Update is called once per frame
    private void Start()
    {
    }
    void Update() {
        

        // walking
        Vector3 direction = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
        transform.position += direction * MoveSpeed * Time.deltaTime;
        transform.LookAt(transform.position + direction);

        // ball in hands
        if (IsBallInHands) {

            // hold over head
            if (Input.GetKey(KeyCode.Space)) {
                Ball.position = PosOverHead.position;
                Arms.localEulerAngles = Vector3.right * 180;

                // look towards the target
                transform.LookAt(Target.parent.position);
            }

            // dribbling
            else {
                Ball.position = PosDribble.position + Vector3.up * Mathf.Abs(Mathf.Sin(Time.time * 3));
                Arms.localEulerAngles = Vector3.right * 0;
            }

            //throw ball
            if (Input.GetKeyUp(KeyCode.Space))
            {
                IsBallInHands = false;
                IsBallFlying = true;
                T = 0;
            }

        }

        // ball in the air
        if (IsBallFlying) {
            T += Time.deltaTime;
            float duration = 1.4f;
            float t01 = T / duration;

            // move to target
            Vector3 A = PosOverHead.position;
            Vector3 B = Target.position;
            Vector3 pos = Vector3.Lerp(A, B, t01);

            // move in arc
            Vector3 arc = Vector3.up * 5 * Mathf.Sin(t01 * 3.14f);

            Ball.position = pos + arc;

            // moment when ball arrives at the target
            if (t01 >= 1) {
                IsBallFlying = false;
                Ball.GetComponent<Rigidbody>().isKinematic = false;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {

        if (!IsBallInHands && !IsBallFlying)
        {

            IsBallInHands = true;
            Ball.GetComponent<Rigidbody>().isKinematic = true;
        }
    }
    //fýrlatma için fonksiyon
    public void atisYap()
    {
        IsBallInHands = false;
        IsBallFlying = true;
        T = 0;
        //oyunBittiMi = true;
        //if (oyunBittiMi == true)
        //{
        //    Invoke("restart", 4f);
        //}
    }
    private void restart()
    {
        skorCek = ses.sayi;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
