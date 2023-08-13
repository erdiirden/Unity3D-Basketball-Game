using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class skorKaydet : MonoBehaviour
{
    public static Text skorGosterBir, skorGosteriki, skorGosterUc;
    void Start()
    {
        skorGosterBir = skorGosterBir.GetComponent<Text>();
        skorGosteriki = skorGosteriki.GetComponent<Text>();
        skorGosterUc = skorGosterUc.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
