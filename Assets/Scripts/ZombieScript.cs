using DG.Tweening;
using MoreMountains.Feedbacks;
using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class ZombieScript : Damageable
{
    GameObject target;
    NavMeshAgent agent;

    public float attackCooldown = 1; //seconds between possible attacks
    float lastAttack = 0;
    public int damage = 1;

    //Feedbacks
    public MMF_Player damagePlayer;
    public MMF_Player walkerPlayer;
    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        target = GameManager.instance.players[Random.Range(0, GameManager.instance.players.Count)];
        walkerPlayer.PlayFeedbacks();
        //healthBar.maxValue = health;
    }
    private void Update()
    {
        if (Vector3.Distance(transform.position, target.transform.position) <= agent.stoppingDistance)
        {
            Attack();
        }
        else
        {
            Chase();
        }
    }

    void Chase()
    {
        agent.SetDestination(target.transform.position);
    }
    void Attack()
    {
        if (Time.time - lastAttack > attackCooldown)
        {
            lastAttack = Time.time;
            PhotonView photonView = PhotonView.Get(target.gameObject);
            photonView.RPC("ReceiveDamageRPC", RpcTarget.All, damage);
        }
    }

    [PunRPC]
    void ReceiveDamageRPC(int damage)
    {
        Debug.Log(gameObject + " received " + damage + " damage.");
        damagePlayer.PlayFeedbacks();
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
