using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    public string productName;
    public int damage;
    public float speed;
    public int ammo;
    public int magazineSize;
    public int magazine;
    public int reloadTime;
    public float range;
    public int bulletCount;
    public bool isReloading;
    public GameObject weaponObject;
    public GameObject bullet;
    public BulletManager b = new BulletManager();
    public GameObject player;

    Vector3 mousePos;
    Vector2 lookDir;
    float angle;

    public abstract void Initialize();
    public Weapon(GameObject weaponObject, GameObject player)
    {
        this.weaponObject = weaponObject;
        this.player = player;
    }
    public void Shoot()
    {
        if (!isReloading)
        {
            magazine--;
            Debug.Log("Shooting");
            b.BulletInstantiate(bullet,this, player);
        }
        else
        {
            Debug.Log("Reloading right now... Please wait!");
        }
    }
    public void Reload()
    {
        isReloading = true;
        if(ammo > magazineSize)
        {
            ammo -= magazineSize - magazine;
            magazine = magazineSize;
        }
        else
        {
            magazine = ammo;
            ammo = 0;
        }
        Debug.Log("Reloading");
        //System.Threading.Thread.Sleep(1000 * reloadTime);
        isReloading = false;
    }

    public void WeaponDirection()
    {
        // Weapon rotation must be equal to the mouse direction
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        lookDir = mousePos - weaponObject.transform.position;
        angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        weaponObject.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
    }
}
