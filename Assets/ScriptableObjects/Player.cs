using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    private string id;
    private string name;
    private int health;
    private Sprite PlayerFaceIcon;
    private WeaponSO weapon;
    public AimController aimController;
    public Animator animator;
    public Sprite profilePic;

    
    
    [SerializeField] private Transform WeaponHodlingPoint;
  


    public void InitPlayer(string id, string name,Sprite playerFaceIcon, WeaponSO weapon, int health, Sprite profilePic) {
        
        this.id = id;
        this.name = name;
        this.health = health;
        this.PlayerFaceIcon = playerFaceIcon;
        this.weapon = weapon;
        this.aimController = this.transform.GetComponentInChildren<AimController>();
        this.WeaponHodlingPoint = aimController.shotPoint;
        this.profilePic = profilePic;
        this.animator = GetComponent<Animator>();

    }

    public void TakeDamage(int damage) {
        this.health -= damage;

        EventHandler.instance.TakeDamage(this, damage);
    }


    public string GetID() { return id; }
    public string GetName() { return name; }
    public GameObject NewWeapon() {
        Vector3 pos = this.transform.position;
        return weapon.InitializeWeapon(WeaponHodlingPoint.position);
    }
    public Transform GetWeaponHoldingPoint() { return WeaponHodlingPoint; }
    public Sprite FaceIcon() {
        return PlayerFaceIcon;
    }

   
}
