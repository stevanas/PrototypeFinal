using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitboxLogic : MonoBehaviour
{
    public int damage;
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Enemy"))
        {
            PhotonView photonView = PhotonView.Get(other.gameObject);
            photonView.RPC("ReceiveDamageRPC", RpcTarget.All, damage);
        }
    }
}
