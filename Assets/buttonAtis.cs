using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class buttonAtis : MonoBehaviour
{

    public float guc;
    [SerializeField] float maxGuc = 40; //bluestack uygun deðer 40
    bool butonaBasili;
    [SerializeField] float dolumHizi = 13; //bluestack uygun deðer 13
    GameObject top;
    float basPozisyon;
    float bitPozisyon;
    float posFark;
    bool oyunBittiMi = false;
    public static int skorCek;
    public  int atisSayac;
    //public int atisSayacSakla;

    #region Instance 
    public static buttonAtis instance;
    private void Awake()
    {
        instance = this;
    }
    #endregion
    void Start()
    {
        basPozisyon = gameObject.transform.position.x;
        //Debug.Log(PlayerPrefs.GetInt("sayac"));
        if (PlayerPrefs.GetInt("sayac") >= 5)
        {
            ses.instance.defeat.SetActive(true);
            PlayerPrefs.DeleteKey("sayac");
        }
    }

    void Update()
    {
        if (butonaBasili == false)
        {
            guc = Time.deltaTime * dolumHizi;
            if (guc > maxGuc)
            {
                guc = maxGuc;
            }
        }

    }
    public void pointerUp()
    {
        butonaBasili = false;
        GetComponent<kontroljoystick>().enabled = false;
        GetComponent<SphereCollider>().material.bounciness = 0;
        var rigidbody = GetComponent<Rigidbody>();
        bitPozisyon = gameObject.transform.position.x;
        posFark = basPozisyon - bitPozisyon;
        rigidbody.velocity = new Vector3(posFark * guc * 1.2f, 25f * guc, 16f * guc);
        oyunBittiMi = true;
        if (PlayerPrefs.GetInt("sayac") <= 4)
        {
            PlayerPrefs.SetInt("sayac", PlayerPrefs.GetInt("sayac")+1);
        }
        //else
        //{
        //    ses.instance.defeat.SetActive(true);
        //    PlayerPrefs.DeleteKey("sayac");
        //}
        if (oyunBittiMi == true)
        {
            //StartCoroutine(ses.instance.TopKaybet());
            Invoke("restart", 5f);
        }

    }

    public void pointerDown()
    {
        GetComponent<kontroljoystick>().enabled = false;
        butonaBasili = true;
    }
    private void restart()
    {
        skorCek = ses.sayi;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
