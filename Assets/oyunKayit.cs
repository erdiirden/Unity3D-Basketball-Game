using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using UnityEngine.UI;

public class oyunKayit : MonoBehaviour
{
    public static int kayitSayi;
    public  Text kayit1, kayit2, kayit3;
    void Start()
    {
        kayitSayi = ses.sayi;
    }

    public void oyunKaydetBir()
    {
        PlayerPrefs.SetInt("Oyun1", kayitSayi);
        PlayerPrefs.Save();
        kayit1.text = "KAYDEDÝLDÝ SKOR: " + kayitSayi;
    }
    public void oyunKaydetIki()
    {
        PlayerPrefs.SetInt("Oyun2", kayitSayi);
        PlayerPrefs.Save();
        kayit2.text = "KAYDEDÝLDÝ SKOR: " + kayitSayi;
    }
    public void oyunKaydetUc()
    {
        PlayerPrefs.SetInt("Oyun3", kayitSayi);
        PlayerPrefs.Save();
        kayit3.text = "KAYDEDÝLDÝ SKOR: " + kayitSayi;
    }
    //public void oyunYukleBir(string oyun)
    //{
    //    buttonAtis.skorCek = PlayerPrefs.GetInt("Oyun1");
    //    oyunaAc(oyun);
    //}
    //public void oyunYukleIki(string oyun)
    //{
    //    buttonAtis.skorCek = PlayerPrefs.GetInt("Oyun2");
    //    oyunaAc(oyun);
    //}
    //public void oyunYukleUc(string oyun)
    //{
    //    buttonAtis.skorCek = PlayerPrefs.GetInt("Oyun3");
    //    oyunaAc(oyun);
    //}
    //public void oyunaAc(string oyun)
    //{
    //    SceneManager.LoadScene(oyun);
    //}
    public void oyunaGirisEkrani(string girisEkrani)
    {
        SceneManager.LoadScene(girisEkrani);
    }
}
