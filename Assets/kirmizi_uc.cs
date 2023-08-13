using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kirmizi_uc : MonoBehaviour
{
    public GameObject top;
    public Animator topSektir;
    public Animator topSut;

    public static kirmizi_uc Instance;
    private void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        topSektir = GetComponent<Animator>();
        topSut = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "top")
        {
            oyuncukontrol.Instance.topKimde = "kirmizi3";
            oyuncukontrol.Instance.topHangiTakimda = false;
            mavi_bir.Instance.topSektir.SetBool("m1sektir", false);
            mavi_iki.Instance.topSektir.SetBool("m2sektir", false);
            mavi_uc.Instance.topSektir.SetBool("m3sektir", false);
            kirmizi_bir.Instance.topSektir.SetBool("k1sektir", false);
            kirmizi_iki.Instance.topSektir.SetBool("k2sektir", false);
            topSektir.SetBool("k3sektir", true);
        }
    }
}
