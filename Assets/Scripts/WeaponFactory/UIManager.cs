using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private GameObject sniperFactory;
    [SerializeField]
    private GameObject pistolFactory;
    [SerializeField]
    private GameObject shotgunFactory;
    [SerializeField]
    private GameObject rifleFactory;
    [SerializeField]
    private GameObject player;

    Vector2 gunPosition;
    Weapon myWeapon;
    enum PistolType
    {
        PISTOL_TYPE_1 = 0,
        PISTOL_TYPE_2 = 1,
        PISTOL_TYPE_3 = 2
    }
    enum RifleType
    {
        RIFLE_TYPE_1 = 0,
        RIFLE_TYPE_2 = 1,
        RIFLE_TYPE_3 = 2
    }
    enum ShotgunType
    {
        SHOTGUN_TYPE_1 = 0,
        SHOTGUN_TYPE_2 = 1,
        SHOTGUN_TYPE_3 = 2
    }
    enum SniperType
    {
        SNIPER_TYPE_1 = 0,
        SNIPER_TYPE_2 = 1,
        SNIPER_TYPE_3 = 2
    }

    private void Awake()
    {
        gunPosition = GameObject.Find("GunPlaceHolder").transform.position;
        myWeapon = pistolFactory.GetComponent<PistolFactory>().CreateWeapon((int)PistolType.PISTOL_TYPE_1, gunPosition, player);
        myWeapon.Initialize();
        myWeapon.weaponObject.transform.SetParent(GameObject.Find("GunPlaceHolder").transform);
        myWeapon.weaponObject.GetComponent<SpriteRenderer>().sortingLayerName = "Weapon";
    }

    private void Update()
    {
        if(myWeapon.magazine > 0 && Input.GetKeyUp(KeyCode.Mouse0))
        {
            myWeapon.Shoot();
        }
        if ((myWeapon.magazine == 0 && myWeapon.ammo > 0) || (Input.GetKeyUp(KeyCode.R) && myWeapon.magazine < myWeapon.magazineSize))
        {
            myWeapon.Reload();
        }
        myWeapon.WeaponDirection();
    }
}
