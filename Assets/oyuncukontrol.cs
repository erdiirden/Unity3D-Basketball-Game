using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class oyuncukontrol : MonoBehaviour
{
    public GameObject ktakim1;
    public GameObject ktakim2;
    public GameObject ktakim3;
    public GameObject mtakim1;
    public GameObject mtakim2;
    public GameObject mtakim3;

    /*public Rigidbody mtkm1, mtkm2, mtkm3, ktkm1, ktkm2, ktkm3;*/ // karakterlerin y�r�me i�in

    public GameObject top;
    float mesafeM1K1, mesafeM1K2, mesafeM1K3 = 0; //M1: mavi1 oyuncusu, K1: kirmizi1 oyuncusu
    float mesafeM2K1, mesafeM2K2, mesafeM2K3 = 0;
    float mesafeM3K1, mesafeM3K2, mesafeM3K3 = 0;
    float[] mesafeKarsilastir = new float[9]; //kar��la�t�rma i�in dizi
    float enAzMesafe; //en az mesafeyi e�itlemek i�in de�i�ken
    float markajda = 4.5f;
    public GameObject m1_isinla, m2_isinla, m3_isinla, k1_isinla, k2_isinla, k3_isinla; //sadece tak�m arkada��na pas i�in top kaybetme i�in k lar tan�mlanmad�

    public bool topHangiTakimda= true; //true mavi (bizim tak�m), false k�rm�z� rakip tak�m
    public string topKimde = "bosta"; //mavi1 , mavi2, mavi3, kirmizi1, kirmizi2, kirmizi3 (mavi iki oyunu oynayan ki�i) , di�er scriptlerden de�i�iyor.

    public static oyuncukontrol Instance;
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

        if (topHangiTakimda == true) //top bizim tak�mda
        {
            
            if (topKimde == "mavi1")
            {

                Array.Clear(mesafeKarsilastir, 0, mesafeKarsilastir.Length); // dizi i�ini temizleme

                mesafeM1K1 = Vector3.Distance(mtakim1.transform.position, ktakim1.transform.position); //mavi1 oyuncusu ile k1 oyuncusunun mesafesi
                mesafeKarsilastir[0] = mesafeM1K1; // bulunan mesafeyi mesafeKarsilastir dizisinin ilk eleman�na atama

                mesafeM1K2 = Vector3.Distance(mtakim1.transform.position, ktakim2.transform.position);
                mesafeKarsilastir[1] = mesafeM1K2;

                mesafeM1K3 = Vector3.Distance(mtakim1.transform.position, ktakim3.transform.position);
                mesafeKarsilastir[2] = mesafeM1K3;

                if (mesafeKarsilastir[0] < markajda || mesafeKarsilastir[1] < markajda || mesafeKarsilastir[2] < markajda) //rakip oyunculardan herhangi biri markaj mesafesinin alt�nda m�?
                {
                    //uygun oyuncuya pas ver

                    Array.Clear(mesafeKarsilastir, 0, mesafeKarsilastir.Length); // dizi i�ini temizleme

                    mesafeM2K1 = Vector3.Distance(mtakim2.transform.position, ktakim1.transform.position); //pas atmak i�in uygun oyuncuyu bulma
                    mesafeKarsilastir[0] = mesafeM2K1; // bulunan mesafeyi diziye atama

                    mesafeM2K2 = Vector3.Distance(mtakim2.transform.position, ktakim2.transform.position); //pas atmak i�in uygun oyuncuyu bulma
                    mesafeKarsilastir[1] = mesafeM2K2; // bulunan mesafeyi diziye atama

                    mesafeM2K3 = Vector3.Distance(mtakim2.transform.position, ktakim3.transform.position); //pas atmak i�in uygun oyuncuyu bulma
                    mesafeKarsilastir[2] = mesafeM2K3; // bulunan mesafeyi diziye atama

                    mesafeM3K1 = Vector3.Distance(mtakim3.transform.position, ktakim1.transform.position); //pas atmak i�in uygun oyuncuyu bulma
                    mesafeKarsilastir[3] = mesafeM3K1; // bulunan mesafeyi diziye atama

                    mesafeM3K2 = Vector3.Distance(mtakim3.transform.position, ktakim2.transform.position); //pas atmak i�in uygun oyuncuyu bulma
                    mesafeKarsilastir[4] = mesafeM3K2; // bulunan mesafeyi diziye atama

                    mesafeM3K3 = Vector3.Distance(mtakim3.transform.position, ktakim3.transform.position); //pas atmak i�in uygun oyuncuyu bulma
                    mesafeKarsilastir[5] = mesafeM3K3; // bulunan mesafeyi diziye atama

                    enAzMesafe = mesafeKarsilastir[0]; //once ilk eleman� en k�c�k mesafe olarak atad�k

                    for (int i = 0; i < mesafeKarsilastir.Length; i++)
                    {
                        if (mesafeKarsilastir[i] < enAzMesafe)
                        {
                            enAzMesafe = mesafeKarsilastir[i]; //en k���k mesafeyi diziden bulup enAzMesafe de�i�kenine atama
                        }
                    }

                    if (enAzMesafe == mesafeKarsilastir[0] || enAzMesafe == mesafeKarsilastir[1] || enAzMesafe == mesafeKarsilastir[2])
                    {
                        //m3 e pas verilecek! (en az mesafe olana de�il di�er oyuncumuza pas verece�iz)
                        top.gameObject.transform.position = m3_isinla.gameObject.transform.position;
                    }

                    if (enAzMesafe == mesafeKarsilastir[3] || enAzMesafe == mesafeKarsilastir[4] || enAzMesafe == mesafeKarsilastir[5])
                    {
                        //m2 ye pas verilecek! (en az mesafe olana de�il di�er oyuncumuza pas verece�iz)
                        top.gameObject.transform.position = m2_isinla.gameObject.transform.position;
                    }
                }
            }
            if (topKimde == "mavi2")
            {
                //m2 oyuncumuz farkl� scriptte biz yap�yoruz i�lemleri (mavi_iki)
            }
            if (topKimde == "mavi3")
            {
                Array.Clear(mesafeKarsilastir, 0, mesafeKarsilastir.Length); // dizi i�ini temizleme

                mesafeM3K1 = Vector3.Distance(mtakim3.transform.position, ktakim1.transform.position); //mavi1 oyuncusu ile k1 oyuncusunun mesafesi
                mesafeKarsilastir[0] = mesafeM3K1; // bulunan mesafeyi mesafeKarsilastir dizisinin ilk eleman�na atama

                mesafeM3K2 = Vector3.Distance(mtakim3.transform.position, ktakim2.transform.position);
                mesafeKarsilastir[1] = mesafeM3K2;

                mesafeM3K3 = Vector3.Distance(mtakim3.transform.position, ktakim3.transform.position);
                mesafeKarsilastir[2] = mesafeM3K3;

                if (mesafeKarsilastir[0] < markajda || mesafeKarsilastir[1] < markajda || mesafeKarsilastir[2] < markajda) //rakip oyunculardan herhangi biri markaj mesafesinin alt�nda m�?
                {
                    //uygun oyuncuya pas ver

                    Array.Clear(mesafeKarsilastir, 0, mesafeKarsilastir.Length); // dizi i�ini temizleme

                    mesafeM1K1 = Vector3.Distance(mtakim1.transform.position, ktakim1.transform.position); //pas atmak i�in uygun oyuncuyu bulma
                    mesafeKarsilastir[0] = mesafeM1K1; // bulunan mesafeyi diziye atama

                    mesafeM1K2 = Vector3.Distance(mtakim1.transform.position, ktakim2.transform.position); //pas atmak i�in uygun oyuncuyu bulma
                    mesafeKarsilastir[1] = mesafeM1K2; // bulunan mesafeyi diziye atama

                    mesafeM1K3 = Vector3.Distance(mtakim1.transform.position, ktakim3.transform.position); //pas atmak i�in uygun oyuncuyu bulma
                    mesafeKarsilastir[2] = mesafeM1K3; // bulunan mesafeyi diziye atama

                    mesafeM2K1 = Vector3.Distance(mtakim2.transform.position, ktakim1.transform.position); //pas atmak i�in uygun oyuncuyu bulma
                    mesafeKarsilastir[0] = mesafeM2K1; // bulunan mesafeyi diziye atama

                    mesafeM2K2 = Vector3.Distance(mtakim2.transform.position, ktakim2.transform.position); //pas atmak i�in uygun oyuncuyu bulma
                    mesafeKarsilastir[1] = mesafeM2K2; // bulunan mesafeyi diziye atama

                    mesafeM2K3 = Vector3.Distance(mtakim2.transform.position, ktakim3.transform.position); //pas atmak i�in uygun oyuncuyu bulma
                    mesafeKarsilastir[2] = mesafeM2K3; // bulunan mesafeyi diziye atama

                    enAzMesafe = mesafeKarsilastir[0]; //once ilk eleman� en k�c�k mesafe olarak atad�k

                    for (int i = 0; i < mesafeKarsilastir.Length; i++)
                    {
                        if (mesafeKarsilastir[i] < enAzMesafe)
                        {
                            enAzMesafe = mesafeKarsilastir[i]; //en k���k mesafeyi diziden bulup enAzMesafe de�i�kenine atama
                        }
                    }

                    if (enAzMesafe == mesafeKarsilastir[0] || enAzMesafe == mesafeKarsilastir[1] || enAzMesafe == mesafeKarsilastir[2])
                    {
                        //m2 e pas verilecek! (en az mesafe olana de�il di�er oyuncumuza pas verece�iz)
                        top.gameObject.transform.position = m2_isinla.gameObject.transform.position;
                    }

                    if (enAzMesafe == mesafeKarsilastir[3] || enAzMesafe == mesafeKarsilastir[4] || enAzMesafe == mesafeKarsilastir[5])
                    {
                        //m1 ye pas verilecek! (en az mesafe olana de�il di�er oyuncumuza pas verece�iz)
                        top.gameObject.transform.position = m1_isinla.gameObject.transform.position;
                    }
                }
            }
        }
        else if (topHangiTakimda == false)
        {
            //rakip tak�m�n en yak�n oyuncusu bask� yapacak - TOP KIRMIZI TAKIMDA RAK�P MAV� TAKIM
            if (topKimde == "kirmizi1")
            {
                Array.Clear(mesafeKarsilastir, 0, mesafeKarsilastir.Length); // dizi i�ini temizleme

                mesafeM1K1 = Vector3.Distance(mtakim1.transform.position, ktakim1.transform.position); //mavi1 oyuncusu ile k1 oyuncusunun mesafesi
                mesafeKarsilastir[0] = mesafeM1K1; // bulunan mesafeyi mesafeKarsilastir dizisinin ilk eleman�na atama

                mesafeM2K1 = Vector3.Distance(mtakim2.transform.position, ktakim1.transform.position);
                mesafeKarsilastir[1] = mesafeM2K1;

                mesafeM3K1 = Vector3.Distance(mtakim3.transform.position, ktakim1.transform.position);
                mesafeKarsilastir[2] = mesafeM3K1;

                if (mesafeKarsilastir[0] < markajda || mesafeKarsilastir[1] < markajda || mesafeKarsilastir[2] < markajda) //rakip oyunculardan herhangi biri markaj mesafesinin alt�nda m�?
                {
                    //uygun oyuncuya pas ver

                    Array.Clear(mesafeKarsilastir, 0, mesafeKarsilastir.Length); // dizi i�ini temizleme

                    mesafeM1K2 = Vector3.Distance(mtakim1.transform.position, ktakim2.transform.position); //pas atmak i�in uygun oyuncuyu bulma
                    mesafeKarsilastir[0] = mesafeM1K2; // bulunan mesafeyi diziye atama

                    mesafeM2K2 = Vector3.Distance(mtakim2.transform.position, ktakim2.transform.position); //pas atmak i�in uygun oyuncuyu bulma
                    mesafeKarsilastir[1] = mesafeM2K2; // bulunan mesafeyi diziye atama

                    mesafeM3K2 = Vector3.Distance(mtakim3.transform.position, ktakim2.transform.position); //pas atmak i�in uygun oyuncuyu bulma
                    mesafeKarsilastir[2] = mesafeM3K2; // bulunan mesafeyi diziye atama

                    mesafeM1K3 = Vector3.Distance(mtakim1.transform.position, ktakim3.transform.position); //pas atmak i�in uygun oyuncuyu bulma
                    mesafeKarsilastir[3] = mesafeM1K3; // bulunan mesafeyi diziye atama

                    mesafeM2K3 = Vector3.Distance(mtakim2.transform.position, ktakim3.transform.position); //pas atmak i�in uygun oyuncuyu bulma
                    mesafeKarsilastir[4] = mesafeM2K3; // bulunan mesafeyi diziye atama

                    mesafeM3K3 = Vector3.Distance(mtakim3.transform.position, ktakim3.transform.position); //pas atmak i�in uygun oyuncuyu bulma
                    mesafeKarsilastir[5] = mesafeM3K3; // bulunan mesafeyi diziye atama

                    enAzMesafe = mesafeKarsilastir[0]; //once ilk eleman� en k�c�k mesafe olarak atad�k

                    for (int i = 0; i < mesafeKarsilastir.Length; i++)
                    {
                        if (mesafeKarsilastir[i] < enAzMesafe)
                        {
                            enAzMesafe = mesafeKarsilastir[i]; //en k���k mesafeyi diziden bulup enAzMesafe de�i�kenine atama
                        }
                    }

                    if (enAzMesafe == mesafeKarsilastir[0] || enAzMesafe == mesafeKarsilastir[1] || enAzMesafe == mesafeKarsilastir[2])
                    {
                        //k3 e pas verilecek! (en az mesafe olana de�il di�er oyuncumuza pas verece�iz)
                        top.gameObject.transform.position = k3_isinla.gameObject.transform.position;
                    }

                    if (enAzMesafe == mesafeKarsilastir[3] || enAzMesafe == mesafeKarsilastir[4] || enAzMesafe == mesafeKarsilastir[5])
                    {
                        //k2 ye pas verilecek! (en az mesafe olana de�il di�er oyuncumuza pas verece�iz)
                        top.gameObject.transform.position = k2_isinla.gameObject.transform.position;
                    }
                }
            }

            if (topKimde == "kirmizi2")
            {
                Array.Clear(mesafeKarsilastir, 0, mesafeKarsilastir.Length); // dizi i�ini temizleme

                mesafeM1K2 = Vector3.Distance(mtakim1.transform.position, ktakim2.transform.position); //mavi1 oyuncusu ile k1 oyuncusunun mesafesi
                mesafeKarsilastir[0] = mesafeM1K1; // bulunan mesafeyi mesafeKarsilastir dizisinin ilk eleman�na atama

                mesafeM2K2 = Vector3.Distance(mtakim2.transform.position, ktakim2.transform.position);
                mesafeKarsilastir[1] = mesafeM2K1;

                mesafeM3K2 = Vector3.Distance(mtakim3.transform.position, ktakim2.transform.position);
                mesafeKarsilastir[2] = mesafeM3K1;

                if (mesafeKarsilastir[0] < markajda || mesafeKarsilastir[1] < markajda || mesafeKarsilastir[2] < markajda) //rakip oyunculardan herhangi biri markaj mesafesinin alt�nda m�?
                {
                    //uygun oyuncuya pas ver

                    Array.Clear(mesafeKarsilastir, 0, mesafeKarsilastir.Length); // dizi i�ini temizleme

                    mesafeM1K1 = Vector3.Distance(mtakim1.transform.position, ktakim1.transform.position); //pas atmak i�in uygun oyuncuyu bulma
                    mesafeKarsilastir[0] = mesafeM1K1; // bulunan mesafeyi diziye atama

                    mesafeM2K1 = Vector3.Distance(mtakim2.transform.position, ktakim1.transform.position); //pas atmak i�in uygun oyuncuyu bulma
                    mesafeKarsilastir[1] = mesafeM2K1; // bulunan mesafeyi diziye atama

                    mesafeM3K1 = Vector3.Distance(mtakim3.transform.position, ktakim1.transform.position); //pas atmak i�in uygun oyuncuyu bulma
                    mesafeKarsilastir[2] = mesafeM3K1; // bulunan mesafeyi diziye atama

                    mesafeM1K3 = Vector3.Distance(mtakim1.transform.position, ktakim3.transform.position); //pas atmak i�in uygun oyuncuyu bulma
                    mesafeKarsilastir[3] = mesafeM1K3; // bulunan mesafeyi diziye atama

                    mesafeM2K3 = Vector3.Distance(mtakim2.transform.position, ktakim3.transform.position); //pas atmak i�in uygun oyuncuyu bulma
                    mesafeKarsilastir[4] = mesafeM2K3; // bulunan mesafeyi diziye atama

                    mesafeM3K3 = Vector3.Distance(mtakim3.transform.position, ktakim3.transform.position); //pas atmak i�in uygun oyuncuyu bulma
                    mesafeKarsilastir[5] = mesafeM3K3; // bulunan mesafeyi diziye atama

                    enAzMesafe = mesafeKarsilastir[0]; //once ilk eleman� en k�c�k mesafe olarak atad�k

                    for (int i = 0; i < mesafeKarsilastir.Length; i++)
                    {
                        if (mesafeKarsilastir[i] < enAzMesafe)
                        {
                            enAzMesafe = mesafeKarsilastir[i]; //en k���k mesafeyi diziden bulup enAzMesafe de�i�kenine atama
                        }
                    }

                    if (enAzMesafe == mesafeKarsilastir[0] || enAzMesafe == mesafeKarsilastir[1] || enAzMesafe == mesafeKarsilastir[2])
                    {
                        //k3 e pas verilecek! (en az mesafe olana de�il di�er oyuncumuza pas verece�iz)
                        top.gameObject.transform.position = k3_isinla.gameObject.transform.position;
                    }

                    if (enAzMesafe == mesafeKarsilastir[3] || enAzMesafe == mesafeKarsilastir[4] || enAzMesafe == mesafeKarsilastir[5])
                    {
                        //k1 ye pas verilecek! (en az mesafe olana de�il di�er oyuncumuza pas verece�iz)
                        top.gameObject.transform.position = k1_isinla.gameObject.transform.position;
                    }
                }
            }

            if (topKimde == "kirmizi3")
            {
                Array.Clear(mesafeKarsilastir, 0, mesafeKarsilastir.Length); // dizi i�ini temizleme

                mesafeM1K3 = Vector3.Distance(mtakim1.transform.position, ktakim3.transform.position); //mavi1 oyuncusu ile k1 oyuncusunun mesafesi
                mesafeKarsilastir[0] = mesafeM1K1; // bulunan mesafeyi mesafeKarsilastir dizisinin ilk eleman�na atama

                mesafeM2K3 = Vector3.Distance(mtakim2.transform.position, ktakim3.transform.position);
                mesafeKarsilastir[1] = mesafeM2K1;

                mesafeM3K3 = Vector3.Distance(mtakim3.transform.position, ktakim3.transform.position);
                mesafeKarsilastir[2] = mesafeM3K1;

                if (mesafeKarsilastir[0] < markajda || mesafeKarsilastir[1] < markajda || mesafeKarsilastir[2] < markajda) //rakip oyunculardan herhangi biri markaj mesafesinin alt�nda m�?
                {
                    //uygun oyuncuya pas ver

                    Array.Clear(mesafeKarsilastir, 0, mesafeKarsilastir.Length); // dizi i�ini temizleme

                    mesafeM1K1 = Vector3.Distance(mtakim1.transform.position, ktakim1.transform.position); //pas atmak i�in uygun oyuncuyu bulma
                    mesafeKarsilastir[0] = mesafeM1K1; // bulunan mesafeyi diziye atama

                    mesafeM2K1 = Vector3.Distance(mtakim2.transform.position, ktakim1.transform.position); //pas atmak i�in uygun oyuncuyu bulma
                    mesafeKarsilastir[1] = mesafeM2K1; // bulunan mesafeyi diziye atama

                    mesafeM3K1 = Vector3.Distance(mtakim3.transform.position, ktakim1.transform.position); //pas atmak i�in uygun oyuncuyu bulma
                    mesafeKarsilastir[2] = mesafeM3K1; // bulunan mesafeyi diziye atama

                    mesafeM1K2 = Vector3.Distance(mtakim1.transform.position, ktakim2.transform.position); //pas atmak i�in uygun oyuncuyu bulma
                    mesafeKarsilastir[3] = mesafeM1K2; // bulunan mesafeyi diziye atama

                    mesafeM2K2 = Vector3.Distance(mtakim2.transform.position, ktakim2.transform.position); //pas atmak i�in uygun oyuncuyu bulma
                    mesafeKarsilastir[4] = mesafeM2K2; // bulunan mesafeyi diziye atama

                    mesafeM3K2 = Vector3.Distance(mtakim3.transform.position, ktakim2.transform.position); //pas atmak i�in uygun oyuncuyu bulma
                    mesafeKarsilastir[5] = mesafeM3K2; // bulunan mesafeyi diziye atama

                    enAzMesafe = mesafeKarsilastir[0]; //once ilk eleman� en k�c�k mesafe olarak atad�k

                    for (int i = 0; i < mesafeKarsilastir.Length; i++)
                    {
                        if (mesafeKarsilastir[i] < enAzMesafe)
                        {
                            enAzMesafe = mesafeKarsilastir[i]; //en k���k mesafeyi diziden bulup enAzMesafe de�i�kenine atama
                        }
                    }

                    if (enAzMesafe == mesafeKarsilastir[0] || enAzMesafe == mesafeKarsilastir[1] || enAzMesafe == mesafeKarsilastir[2])
                    {
                        //k2 e pas verilecek! (en az mesafe olana de�il di�er oyuncumuza pas verece�iz)
                        top.gameObject.transform.position = k2_isinla.gameObject.transform.position;
                    }

                    if (enAzMesafe == mesafeKarsilastir[3] || enAzMesafe == mesafeKarsilastir[4] || enAzMesafe == mesafeKarsilastir[5])
                    {
                        //k1 ye pas verilecek! (en az mesafe olana de�il di�er oyuncumuza pas verece�iz)
                        top.gameObject.transform.position = k1_isinla.gameObject.transform.position;
                    }
                }
            }

        }


    } //update void

}
