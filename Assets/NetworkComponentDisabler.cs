using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetworkComponentDisabler : MonoBehaviour
{
    //This script is used to disable input, camera etc for the other players. Components that should only work for the connected user.
    FirstPersonMovement movement;
    Jump jump;
    Camera camera;
    MeleeCombat melee;
    PhotonView photonView;
    private void Awake()
    {
        movement = GetComponent<FirstPersonMovement>();
        jump = GetComponent<Jump>();
        camera = GetComponentInChildren<Camera>();
        melee = GetComponent<MeleeCombat>();

        photonView = GetComponent<PhotonView>();
    }

    private void Start()
    {
        if(!photonView.IsMine)
        {
            movement.enabled = false;
            jump.enabled = false;
            Destroy(camera.gameObject);
            melee.enabled = false;
        }
    }
}
