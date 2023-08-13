using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class k1baski : MonoBehaviour
{
    public GameObject m1hedef, m2hedef, m3hedef; //bask�

    public GameObject pota; //h�cum

    public GameObject top;

    public GameObject potaSayi;

    public GameObject oyuncu;

    float mesafe;

    public static k1baski Instance;
    private void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // top rakipte
        if (oyuncukontrol.Instance.topKimde == "mavi1")
        {
            Quaternion targetRotation = Quaternion.LookRotation(m1hedef.transform.position - transform.position);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 10f * Time.deltaTime);
            transform.position += transform.forward * 3f * Time.deltaTime;
        }
        if (oyuncukontrol.Instance.topKimde == "mavi2")
        {
            Quaternion targetRotation = Quaternion.LookRotation(m2hedef.transform.position - transform.position);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 10f * Time.deltaTime);
            transform.position += transform.forward * 2f * Time.deltaTime;
        }
        if (oyuncukontrol.Instance.topKimde == "mavi3")
        {
            Quaternion targetRotation = Quaternion.LookRotation(m3hedef.transform.position - transform.position);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 10f * Time.deltaTime);
            transform.position += transform.forward * 1f * Time.deltaTime;
        }

        // h�cum
        if (oyuncukontrol.Instance.topKimde == "kirmizi1")
        {
            //Quaternion targetRotation = Quaternion.LookRotation(pota.transform.position - transform.position);
            //transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 10f * Time.deltaTime);
            //transform.position += transform.forward * 1f * Time.deltaTime;
            StartCoroutine(Atis());
        }
        if (oyuncukontrol.Instance.topKimde == "kirmizi2")
        {
            Quaternion targetRotation = Quaternion.LookRotation(pota.transform.position - transform.position);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 10f * Time.deltaTime);
            transform.position += transform.forward * 3f * Time.deltaTime;
        }
        if (oyuncukontrol.Instance.topKimde == "kirmizi3")
        {
            Quaternion targetRotation = Quaternion.LookRotation(pota.transform.position - transform.position);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 10f * Time.deltaTime);
            transform.position += transform.forward * 3f * Time.deltaTime;
        }

    }
    IEnumerator Atis()
    {
        yield return new WaitForSeconds(2f);
        mesafe = Vector3.Distance(oyuncu.transform.position, potaSayi.transform.position);
        if (mesafe < 20f)
        {
            StartCoroutine(Atis());
            top.gameObject.transform.position = potaSayi.gameObject.transform.position;
        }
    }
}
