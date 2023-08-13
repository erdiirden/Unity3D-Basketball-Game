using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class oyunagiris : MonoBehaviour
{
    private void Start()
    {
        PlayerPrefs.SetInt("sayac", 0);
    }
    public void SahneDegistir(string oyun)
    {
        SceneManager.LoadScene(oyun);
    }
    public void OyunYukle(string oyunYukle)
    {
        SceneManager.LoadScene(oyunYukle);
    }
    public void OyundanCik()
    {
        Application.Quit(); //Editorde çalýþmaz
    }
}

