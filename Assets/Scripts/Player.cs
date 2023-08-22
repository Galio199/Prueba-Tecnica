using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    #region Singlenton
    private static Player instance;

    public static Player Instance { get { return instance; } }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);

            equipment = new GameObject[3];
            coins = 3;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    #endregion

    public int coins;
    public GameObject[] equipment;

}
