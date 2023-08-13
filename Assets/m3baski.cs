using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class m3baski : MonoBehaviour
{
    public GameObject k1hedef, k2hedef, k3hedef; //baský

    public GameObject pota; //hücum potasý

    public GameObject top;

    public GameObject potaSayi; //atýþ için hedef

    public GameObject oyuncu;

    float mesafe;

    public static m3baski Instance;
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
        if (oyuncukontrol.Instance.topKimde == "kirmizi1")
        {
            Quaternion targetRotation = Quaternion.LookRotation(k1hedef.transform.position - transform.position);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 10f * Time.deltaTime);
            transform.position += transform.forward * 1f * Time.deltaTime;
        }
        if (oyuncukontrol.Instance.topKimde == "kirmizi2")
        {
            Quaternion targetRotation = Quaternion.LookRotation(k2hedef.transform.position - transform.position);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 10f * Time.deltaTime);
            transform.position += transform.forward * 2f * Time.deltaTime;
        }
        if (oyuncukontrol.Instance.topKimde == "kirmizi3")
        {
            Quaternion targetRotation = Quaternion.LookRotation(k3hedef.transform.position - transform.position);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 10f * Time.deltaTime);
            transform.position += transform.forward * 3f * Time.deltaTime;
        }

        // hücum
        if (oyuncukontrol.Instance.topKimde == "mavi1")
        {
            Quaternion targetRotation = Quaternion.LookRotation(pota.transform.position - transform.position);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 10f * Time.deltaTime);
            transform.position += transform.forward * 3f * Time.deltaTime;
        }
        if (oyuncukontrol.Instance.topKimde == "mavi2")
        {
            Quaternion targetRotation = Quaternion.LookRotation(pota.transform.position - transform.position);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 10f * Time.deltaTime);
            transform.position += transform.forward * 3f * Time.deltaTime;
        }
        if (oyuncukontrol.Instance.topKimde == "mavi3")
        {
            //Quaternion targetRotation = Quaternion.LookRotation(pota.transform.position - transform.position);
            //transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 10f * Time.deltaTime);
            //transform.position += transform.forward * 3f * Time.deltaTime;
            StartCoroutine(Atis());
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
