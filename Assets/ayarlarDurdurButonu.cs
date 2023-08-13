using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ayarlarDurdurButonu : MonoBehaviour
{
    public void SahneDegistir(string ayarlarDurdur)
    {
        //Time.timeScale = 0f;
        SceneManager.LoadScene(ayarlarDurdur);
    }
}