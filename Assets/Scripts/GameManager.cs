using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public List<GameObject> players = new List<GameObject>();

    private void Awake()
    {
        if (instance)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        //DontDestroyOnLoad(gameObject);
    }
    public void OnPlayerConnected(GameObject player)
    {
        players.Add(player);
    }
}
