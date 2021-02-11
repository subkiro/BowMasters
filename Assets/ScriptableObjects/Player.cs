﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    private string id;
    private string name;
    private Sprite PlayerFaceIcon;
    private WeaponSO weapon;
    public AimController aimController;
   
    [SerializeField] private Transform WeaponHodlingPoint;
  


    public void InitPlayer(string id, string name,Sprite playerFaceIcon, WeaponSO weapon) {
        this.id = id;
        this.name = name;
        this.PlayerFaceIcon = playerFaceIcon;
        this.weapon = weapon;
        this.aimController = this.transform.GetComponentInChildren<AimController>();
        this.WeaponHodlingPoint = aimController.shotPoint; 

    }




    public string GetID() { return id; }
    public string GetName() { return name; }
    public GameObject NewWeapon() {return weapon.InitializeWeapon(WeaponHodlingPoint);}
    public Transform GetWeaponHoldingPoint() { return WeaponHodlingPoint; }
    public Sprite FaceIcon() {
        return PlayerFaceIcon;
    }

   
}