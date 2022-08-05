using DG.Tweening;
using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Damageable : MonoBehaviourPun
{
    public int health;
    public Slider healthBar;

    private void Awake()
    {
        healthBar.maxValue = health;
        healthBar.value = healthBar.maxValue;
        Debug.Log(healthBar.value);
    }


    protected virtual void OnReceiveDamage(int damage)
    {
        //PhotonView photonView = gameObject.GetComponent<PhotonView>();
        //this.photonView.RPC("ReceiveDamageRPC", RpcTarget.All, damage);
    }
}
