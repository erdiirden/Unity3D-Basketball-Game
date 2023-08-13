using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region Deðiþkenler


    public int para;

    #endregion

    #region Instance
    public static GameManager Instance;
    private void Awake()
    {
        Instance = this;
    }
    #endregion

    private void Start()
    {
        para = 100;

        UIManager.Instance.ParaGüncelle(-15);
    }

}
