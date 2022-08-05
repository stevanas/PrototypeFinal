using DG.Tweening;
using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Damageable
{
    [PunRPC]
    void ReceiveDamageRPC(int damage)
    {
        Debug.Log(gameObject + " received " + damage + " damage.");
        health -= damage;
        healthBar
            .DOValue(health, 0.3f);
        if (health <= 0)
        {
            PhotonView photonView = PhotonView.Get(gameObject);
            photonView.RPC("Die", RpcTarget.All);
        }
    }
    [PunRPC]
    void Die()
    {
        Debug.Log(gameObject + " died!");
        Destroy(gameObject);
    }
}
