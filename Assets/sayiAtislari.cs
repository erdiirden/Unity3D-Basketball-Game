using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sayiAtislari : MonoBehaviour
{
    public Transform mavihedefPota, kirmizihedefPota; //hücum potasý yumuþak atýþ için
    float guc = 13f; //13f uygun deðer  
    public float m1Mesafe, m2Mesafe, m3Mesafe, k1Mesafe, k2Mesafe, k3Mesafe;
    public GameObject maviPota, kirmiziPota; //mesafe için
    public GameObject m1,m2,m3,k1,k2,k3; //mesafe için
    public bool m1sayiat, m2sayiat, m3sayiat, k1sayiat, k2sayiat, k3sayiat = true;

    public static sayiAtislari Instance;
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
        m1Mesafe = Vector3.Distance(m1.transform.position, maviPota.transform.position);
        m2Mesafe = Vector3.Distance(m2.transform.position, maviPota.transform.position);
        m3Mesafe = Vector3.Distance(m3.transform.position, maviPota.transform.position);
        k1Mesafe = Vector3.Distance(k1.transform.position, kirmiziPota.transform.position);
        k2Mesafe = Vector3.Distance(k2.transform.position, kirmiziPota.transform.position);
        k3Mesafe = Vector3.Distance(k3.transform.position, kirmiziPota.transform.position);

        if (m1sayiat == true && oyuncukontrol.Instance.topKimde == "mavi1")
        {
            m1Atisi();
            StartCoroutine(m1beklet());
        }
        if (m2sayiat == true && oyuncukontrol.Instance.topKimde == "mavi2")
        {
            m2Atisi();
            StartCoroutine(m2beklet());
        }
        if (m3sayiat == true && oyuncukontrol.Instance.topKimde == "mavi3")
        {
            m3Atisi();
            StartCoroutine(m3beklet());
        }
        if (k1sayiat == true && oyuncukontrol.Instance.topKimde == "kirmizi1")
        {
            k1Atisi();
            StartCoroutine(k1beklet());
        }
        if (k2sayiat == true && oyuncukontrol.Instance.topKimde == "kirmizi2")
        {
            k2Atisi();
            StartCoroutine(k2beklet());
        }
        if (k3sayiat == true && oyuncukontrol.Instance.topKimde == "kirmizi3")
        {
            k3Atisi();
            StartCoroutine(k3beklet());
        }


    }
    public IEnumerator m3beklet()
    {
        yield return new WaitForSeconds(0.7f);
        StartCoroutine(m3beklet());
        mavi_uc.Instance.topSut.SetBool("m3sut", false);
        mavi_uc.Instance.topSektir.SetBool("m3sektir", false);

    }
    public IEnumerator m2beklet()
    {
        yield return new WaitForSeconds(0.7f);
        StartCoroutine(m2beklet());
        mavi_iki.Instance.topSut.SetBool("m2sut", false);
        mavi_iki.Instance.topSektir.SetBool("m2sektir", false);

    }
    public IEnumerator m1beklet()
    {
        yield return new WaitForSeconds(0.7f);
        StartCoroutine(m1beklet());
        mavi_bir.Instance.topSut.SetBool("m1sut", false);
        mavi_bir.Instance.topSektir.SetBool("m1sektir", false);

    }
    public IEnumerator k1beklet()
    {
        yield return new WaitForSeconds(0.7f);
        StartCoroutine(k1beklet());
        kirmizi_bir.Instance.topSut.SetBool("k1sut", false);
        kirmizi_bir.Instance.topSektir.SetBool("k1sektir", false);

    }
    public IEnumerator k2beklet()
    {
        yield return new WaitForSeconds(0.7f);
        StartCoroutine(k2beklet());
        kirmizi_iki.Instance.topSut.SetBool("k2sut", false);
        kirmizi_iki.Instance.topSektir.SetBool("k2sektir", false);

    }
    public IEnumerator k3beklet()
    {
        yield return new WaitForSeconds(0.7f);
        StartCoroutine(k3beklet());
        kirmizi_uc.Instance.topSut.SetBool("k3sut", false);
        kirmizi_uc.Instance.topSektir.SetBool("k3sektir", false);

    }
    public void m1Atisi()
    {
        if (m1Mesafe < 10f)
        {
            mavi_bir.Instance.topSut.SetBool("m1sut", true);
            GetComponent<SphereCollider>().material.bounciness = 0;
            Vector3 Sut = (mavihedefPota.position - this.transform.position).normalized;
            GetComponent<Rigidbody>().AddForce(Sut * guc, ForceMode.Impulse);
            GetComponent<kontroljoystick>().enabled = false;
            GetComponent<buttonAtis>().enabled = false;
            //GetComponent<SphereCollider>().material.bounciness = 0;
            // oyun yeniden baþlatýlacak
            m1sayiat = false;
        }
    }
    public void m2Atisi()
    {
        if (m2Mesafe < 10f)
        {
            mavi_iki.Instance.topSut.SetBool("m2sut", true);
            GetComponent<SphereCollider>().material.bounciness = 0;
            Vector3 Sut = (mavihedefPota.position - this.transform.position).normalized;
            GetComponent<Rigidbody>().AddForce(Sut * guc, ForceMode.Impulse);
            GetComponent<kontroljoystick>().enabled = false;
            GetComponent<buttonAtis>().enabled = false;
            //GetComponent<SphereCollider>().material.bounciness = 0;
            // oyun yeniden baþlatýlacak
            m2sayiat = false;
        }
    }
    public void m3Atisi()
    {
        if (m3Mesafe < 10f)
        {
            mavi_uc.Instance.topSut.SetBool("m3sut", true);
            GetComponent<SphereCollider>().material.bounciness = 0;
            Vector3 Sut = (mavihedefPota.position - this.transform.position).normalized;
            GetComponent<Rigidbody>().AddForce(Sut * guc, ForceMode.Impulse);
            GetComponent<kontroljoystick>().enabled = false;
            GetComponent<buttonAtis>().enabled = false;
            //GetComponent<SphereCollider>().material.bounciness = 0;
            // oyun yeniden baþlatýlacak
            m3sayiat = false;
        }
    }
    public void k1Atisi()
    {
        if (k1Mesafe < 10f)
        {
            kirmizi_bir.Instance.topSut.SetBool("k1sut", true);
            GetComponent<SphereCollider>().material.bounciness = 0;
            Vector3 Sut = (kirmizihedefPota.position - this.transform.position).normalized;
            GetComponent<Rigidbody>().AddForce(Sut * guc, ForceMode.Impulse);
            GetComponent<kontroljoystick>().enabled = false;
            GetComponent<buttonAtis>().enabled = false;
            //GetComponent<SphereCollider>().material.bounciness = 0;
            // oyun yeniden baþlatýlacak
            k1sayiat = false;
        }
    }
    public void k2Atisi()
    {
        if (k2Mesafe < 10f)
        {
            kirmizi_iki.Instance.topSut.SetBool("k2sut", true);
            GetComponent<SphereCollider>().material.bounciness = 0;
            Vector3 Sut = (kirmizihedefPota.position - this.transform.position).normalized;
            GetComponent<Rigidbody>().AddForce(Sut * guc, ForceMode.Impulse);
            GetComponent<kontroljoystick>().enabled = false;
            GetComponent<buttonAtis>().enabled = false;
            //GetComponent<SphereCollider>().material.bounciness = 0;
            // oyun yeniden baþlatýlacak
            k2sayiat = false;
        }
    }
    public void k3Atisi()
    {
        if (k3Mesafe < 10f)
        {
            kirmizi_uc.Instance.topSut.SetBool("k3sut", true);
            GetComponent<SphereCollider>().material.bounciness = 0;
            Vector3 Sut = (kirmizihedefPota.position - this.transform.position).normalized;
            GetComponent<Rigidbody>().AddForce(Sut * guc, ForceMode.Impulse);
            GetComponent<kontroljoystick>().enabled = false;
            GetComponent<buttonAtis>().enabled = false;
            //GetComponent<SphereCollider>().material.bounciness = 0;
            // oyun yeniden baþlatýlacak
            k3sayiat = false;
        }
    }
}
