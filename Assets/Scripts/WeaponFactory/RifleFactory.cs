using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RifleFactory : MonoBehaviour, IFactory
{
    [SerializeField] private GameObject Rifle1;
    [SerializeField] private GameObject Rifle2;
    [SerializeField] private GameObject Rifle3;

    public const int RIFLE_TYPE_1 = 0;
    public const int RIFLE_TYPE_2 = 1;
    public const int RIFLE_TYPE_3 = 2;
    public Weapon CreateWeapon(int productType, Vector2 position, GameObject player)
    {
        switch (productType)
        {
            case RIFLE_TYPE_1:
                var weapon1 = Instantiate(Rifle1, position, Quaternion.identity);
                return new Rifle1(weapon1, player);
            case RIFLE_TYPE_2:
                var weapon2 = Instantiate(Rifle2, position, Quaternion.identity);
                return new Rifle2(weapon2, player);
            case RIFLE_TYPE_3:
                var weapon3 = Instantiate(Rifle3, position, Quaternion.identity);
                return new Rifle3(weapon3, player);
        }
        return null;
    }
}

public class Rifle1 : Weapon
{
    public Rifle1(GameObject weaponObject, GameObject player) : base(weaponObject, player)
    {

    }
    public override void Initialize()
    {
        productName = "Rifle 1";
        damage = 55;
        speed = 5;
        ammo = 75;
        magazineSize = 25;
        reloadTime = 5;
        range = 10;
        bulletCount = 1;
    }
}

public class Rifle2 : Weapon
{
    public Rifle2(GameObject weaponObject, GameObject player) : base(weaponObject, player)
    {

    }
    public override void Initialize()
    {
        productName = "Rifle 2";
        damage = 55;
        speed = 5;
        ammo = 75;
        magazineSize = 25;
        reloadTime = 5;
        range = 10;
        bulletCount = 1;
    }
}

public class Rifle3 : Weapon
{
    public Rifle3(GameObject weaponObject, GameObject player) : base(weaponObject, player)
    {

    }
    public override void Initialize()
    {
        productName = "Rifle 3";
        damage = 55;
        speed = 5;
        ammo = 75;
        magazineSize = 25;
        reloadTime = 5;
        range = 10;
        bulletCount = 1;
    }
}