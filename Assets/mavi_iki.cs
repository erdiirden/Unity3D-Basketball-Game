using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mavi_iki : MonoBehaviour
{
    public GameObject top;
    float mesafeM1K1 = 0; //M1: mavi1 oyuncusu, K1: kirmizi1 oyuncusu
    float mesafeM1K2 = 0;
    float mesafeM1K3 = 0;
    float mesafeM3K1 = 0;
    float mesafeM3K2 = 0;
    float mesafeM3K3 = 0;
    float[] mesafeKarsilastir = new float[6]; //karþýlaþtýrma için dizi
    float enAzMesafe; //en az mesafeyi eþitlemek için deðiþken
    private GameObject m1,m3,k1,k2,k3; //m2 kendisi , k1,k2,k3 rakipler. Mesafe Karþýlaþtýrma için.
    public GameObject m1_isinla, m2_isinla, m3_isinla; //sadece takým arkadaþýna pas için top kaybetme için k lar tanýmlanmadý
    public Animator topSektir;
    public Animator pas;
    public Animator sut;
    public Animator topSut;


    public static mavi_iki Instance;
    private void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        m1 = oyuncukontrol.Instance.mtakim1; //m2 kendisi , k1,k2,k3 rakipler. Mesafe Karþýlaþtýrma için.
        m3 = oyuncukontrol.Instance.mtakim3;
        k1 = oyuncukontrol.Instance.ktakim1;
        k2 = oyuncukontrol.Instance.ktakim2;
        k3 = oyuncukontrol.Instance.ktakim3;
        top.gameObject.transform.position = m2_isinla.gameObject.transform.position;
        topSektir = GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "top")
        {
            oyuncukontrol.Instance.topKimde = "mavi2";
            oyuncukontrol.Instance.topHangiTakimda = true;

            mavi_bir.Instance.topSektir.SetBool("m1sektir", false);
            topSektir.SetBool("m2sektir", true);
            mavi_uc.Instance.topSektir.SetBool("m3sektir", false);
            kirmizi_bir.Instance.topSektir.SetBool("k1sektir", false);
            kirmizi_iki.Instance.topSektir.SetBool("k2sektir", false);
            kirmizi_uc.Instance.topSektir.SetBool("k3sektir", false);
            
        }
    }
    public void pasButon()
    {
        

        mesafeM1K1 = Vector3.Distance(m1.transform.position, k1.transform.position); //m1 oyuncusu ile k1 oyuncusunun mesafesini bulma
        mesafeKarsilastir[0] = mesafeM1K1; // bulunan mesafeyi mesafeKarsilastir dizisinin ilk elemanýna atama

        mesafeM1K2 = Vector3.Distance(m1.transform.position, k2.transform.position);
        mesafeKarsilastir[1] = mesafeM1K2;

        mesafeM1K3 = Vector3.Distance(m1.transform.position, k3.transform.position);
        mesafeKarsilastir[2] = mesafeM1K3;

        mesafeM3K1 = Vector3.Distance(m3.transform.position, k1.transform.position);
        mesafeKarsilastir[3] = mesafeM3K1;

        mesafeM3K2 = Vector3.Distance(m3.transform.position, k2.transform.position);
        mesafeKarsilastir[4] = mesafeM3K2;

        mesafeM3K3 = Vector3.Distance(m3.transform.position, k3.transform.position);
        mesafeKarsilastir[5] = mesafeM3K3;

        enAzMesafe = mesafeKarsilastir[0]; //once ilk elemaný en kücük mesafe olarak atadýk

        for(int i=0; i<mesafeKarsilastir.Length; i++)  
        {
            if (mesafeKarsilastir[i] < enAzMesafe)
            {
                enAzMesafe = mesafeKarsilastir[i]; //en küçük mesafeyi diziden bulup enAzMesafe deðiþkenine atama
            }
        }

        if (enAzMesafe==mesafeKarsilastir[0] || enAzMesafe == mesafeKarsilastir[1] || enAzMesafe == mesafeKarsilastir[2])
        {
            //m3 e pas verilecek! (en az mesafe olana deðil diðer oyuncumuza pas vereceðiz)
            top.gameObject.transform.position = m3_isinla.gameObject.transform.position;
        }

        if (enAzMesafe == mesafeKarsilastir[3] || enAzMesafe == mesafeKarsilastir[4] || enAzMesafe == mesafeKarsilastir[5])
        {
            //m1 ye pas verilecek! (en az mesafe olana deðil diðer oyuncumuza pas vereceðiz)
            top.gameObject.transform.position = m1_isinla.gameObject.transform.position;
        }
    }
}
