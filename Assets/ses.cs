using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ses : MonoBehaviour
{
    AudioSource audioSource;
    //public AudioClip kacirmaSes;
    public AudioClip basketSes;
    public AudioClip kacirmaSes;
    public Animator animator;
    //public GameObject[] karakul;
    [SerializeField] private Animator[] _animators;
    public GameObject textSkor;
    public Text Skor;
    //public  int skorSakla;
    public static int sayi = 0;
    public bool kacSayi = false; //true2 false3
    ParticleSystem konfeti;
    bool oyunDurdumu = false;
    public GameObject oyundurdufoto;
    public GameObject oyundurdutext;
    public GameObject victory;
    public GameObject defeat;
    bool sesKapandiMi = false;
    public Sprite sesAcikFoto;
    public Sprite sesKapaliFoto;
    public Button sesButon;
    public Button oyunDurdurButon;
    public Sprite oyunDurduFotograf;
    public Sprite oyunDurmadiFotograf;

    public Transform spawnNoktasý;
    public GameObject Top;

    

    #region Instance 
    public static ses instance;
    private void Awake()
    {
        instance = this;
    }
    #endregion

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        Skor = textSkor.GetComponent<Text>();
        Skor.text = "" + sayi;
        konfeti = GameObject.Find("konfeti").GetComponent<ParticleSystem>();
        konfeti.Stop();
        sayi = buttonAtis.skorCek;
        


    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "ucsayi")
        {
            kacSayi = false;
        }
        if (collision.gameObject.tag == "ikisayi")
        {
            kacSayi = true;
        }
        if (collision.gameObject.tag == "ikisayi" && collision.gameObject.tag == "ucsayi")
        {
            kacSayi = true;
        }
    }
    public void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "sayiCollider")
        {
            PlayerPrefs.SetInt("sayac", PlayerPrefs.GetInt("sayac")-1);
            konfeti.Play();
            audioSource.PlayOneShot(basketSes);
            for (int i = 0; i < _animators.Length; i++)
            {
                _animators[i].SetBool("clap", true);
            }
            GetComponent<SphereCollider>().material.bounciness = 0f;

            if (kacSayi == true)
            {
                sayi = sayi + 2;
            }
            else if (kacSayi == false)
            {
                sayi = sayi + 3;
            }
            Skor.text = "" + sayi;
            if (sayi >= 10)
            {
                victory.SetActive(true); //oyun durdurma iþlemi yapýlacak 
            }
            //if (PlayerPrefs.GetInt("sayac") >= 3)
            //{
            //    defeat.SetActive(true); //oyun durdurma iþlemi yapýlacak
            //}

        }
        else
        {
            //audioSource.PlayOneShot(kacirmaSes);
            for (int i = 0; i < _animators.Length; i++)
            {
                _animators[i].SetBool("clap", false);
            }
        }
    }
    //public IEnumerator TopKaybet()
    //{
    //    //cagrýldýgýnda dýrekt calýsacak kodlarýn yerý
    //    yield return new WaitForSeconds(2f);

    //    //cagrýldýgýnda 2 sn sonra calýsacak kodlarýn yerý
       
    //    GetComponent<SphereCollider>().material.bounciness = 0;
    //    yield return new WaitForSeconds(3f);

    //}

    public void oyunDurdur()
    {
        if (oyunDurdumu == false)
        {
            Time.timeScale = 0f;
            oyunDurdumu = true;
            AudioListener.volume = 0f;
            oyundurdufoto.SetActive(true);
            oyundurdutext.SetActive(true);
            oyunDurdurButon.image.sprite = oyunDurduFotograf;
        }
        else
        {
            Time.timeScale = 1f;
            oyunDurdumu = false;
            AudioListener.volume = 1f;
            oyundurdufoto.SetActive(false);
            oyundurdutext.SetActive(false);
            oyunDurdurButon.image.sprite = oyunDurmadiFotograf;

        }
    }
    public void oyunSes()
    {
        if (sesKapandiMi == false)
        {
            AudioListener.volume = 0f;
            sesKapandiMi = true;
            sesButon.image.sprite = sesKapaliFoto;
        }
        else
        {
            AudioListener.volume = 1f;
            sesKapandiMi = false;
            sesButon.image.sprite = sesAcikFoto;
        }
    }
    public void Reset()
    {
        PlayerPrefs.SetInt("sayac", 0);
        SceneManager.LoadScene("oyun"); //düzenle
    }
    public void OyunYukleme(string girisEkrani)
    {
        PlayerPrefs.SetInt("sayac", 0);
        SceneManager.LoadScene(girisEkrani);
    }
    public void OyunKaydet(string oyunKaydet)
    {
        SceneManager.LoadScene(oyunKaydet);
    }
}