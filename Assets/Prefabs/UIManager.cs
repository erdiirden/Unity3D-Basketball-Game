using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Text ParaText;
    public static UIManager Instance;
    private void Awake()
    {
        Instance = this;
    }
    public void ParaG�ncelle(int deger)
    {
        GameManager.Instance.para += deger;
        TextGuncelle();
    }
    public void TextGuncelle()
    {
        ParaText.text = GameManager.Instance.para.ToString();
    }
}
