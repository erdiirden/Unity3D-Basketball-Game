using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class kontroljoystick : MonoBehaviour
{
    public Joystick joystick;

    void Start()
    {
        joystick = FindObjectOfType<Joystick>();
    }

    // Update is called once per frame
    void Update()
    {
        var rigidbody = GetComponent<Rigidbody>();
        rigidbody.velocity = new Vector3(joystick.Horizontal * 4f, rigidbody.velocity.y, joystick.Vertical * 4f);
        rigidbody.angularVelocity = Vector3.forward * 1.2f;
    }

}
