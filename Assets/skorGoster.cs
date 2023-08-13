using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class skorGoster : MonoBehaviour
{

    public Text oyunyukle1, oyunyukle2, oyunyukle3;
    void Start()
    {
        oyunyukle1 = oyunyukle1.GetComponent<Text>();
        oyunyukle2 = oyunyukle2.GetComponent<Text>();
        oyunyukle3 = oyunyukle3.GetComponent<Text>();
        oyunyukle1.text = "YÜKLE SKOR: " + PlayerPrefs.GetInt("Oyun1");
        oyunyukle2.text = "YÜKLE SKOR: " + PlayerPrefs.GetInt("Oyun2");
        oyunyukle3.text = "YÜKLE SKOR: " + PlayerPrefs.GetInt("Oyun3");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void oyunYukleBir(string oyun)
    {
        buttonAtis.skorCek = PlayerPrefs.GetInt("Oyun1");
        oyunaAc(oyun);
    }
    public void oyunYukleIki(string oyun)
    {
        buttonAtis.skorCek = PlayerPrefs.GetInt("Oyun2");
        oyunaAc(oyun);
    }
    public void oyunYukleUc(string oyun)
    {
        buttonAtis.skorCek = PlayerPrefs.GetInt("Oyun3");
        oyunaAc(oyun);
    }
    public void oyunaAc(string oyun)
    {
        SceneManager.LoadScene(oyun);
    }
}
