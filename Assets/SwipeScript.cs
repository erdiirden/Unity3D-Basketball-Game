using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SwipeScript : MonoBehaviour {

	Vector2 startPos, endPos, direction; // touch start position, touch end position, swipe direction
	float touchTimeStart, touchTimeFinish, timeInterval; // to calculate swipe time to sontrol throw force in Z direction

	[SerializeField]
	float throwForceInXandY = 1f; // to control throw force in X and Y directions

	[SerializeField]
	float throwForceInZ = 50f; // to control throw force in Z direction

	Rigidbody rb;
    bool oyunBittiMi=false;

    void Start()
	{
		rb = GetComponent<Rigidbody> ();
    }
	void Update () {

        GetComponent<kontroljoystick>().enabled = false;
        if (Input.touchCount > 0 && Input.GetTouch (0).phase == TouchPhase.Began)
        {
            touchTimeStart = Time.time;
			startPos = Input.GetTouch (0).position;  
        }
        
		if (Input.touchCount > 0 && Input.GetTouch (0).phase == TouchPhase.Ended)
        {
            
            touchTimeFinish = Time.time;
 
			timeInterval = touchTimeFinish - touchTimeStart;
            
			endPos = Input.GetTouch (0).position;
            
			direction = startPos - endPos;
            
			rb.isKinematic = false;
			rb.AddForce (- direction.x * throwForceInXandY, - direction.y * throwForceInXandY, throwForceInZ / timeInterval);
            oyunBittiMi = true;
            if (oyunBittiMi == true)
            {
                Invoke("restart", 4f);
            }
        }

    }
    private void restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
