using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotgunFactory : MonoBehaviour, IFactory
{
    [SerializeField] private GameObject Shotgun1;
    [SerializeField] private GameObject Shotgun2;
    [SerializeField] private GameObject Shotgun3;

    public const int SHOTGUN_TYPE_1 = 0;
    public const int SHOTGUN_TYPE_2 = 1;
    public const int SHOTGUN_TYPE_3 = 2;
    public Weapon CreateWeapon(int productType, Vector2 position, GameObject player)
    {
        switch (productType)
        {
            case SHOTGUN_TYPE_1:
                var weapon1 = Instantiate(Shotgun1, position, Quaternion.identity);
                return new Shotgun1(weapon1, player);
            case SHOTGUN_TYPE_2:
                var weapon2 = Instantiate(Shotgun2, position, Quaternion.identity);
                return new Shotgun2(weapon2, player);
            case SHOTGUN_TYPE_3:
                var weapon3 = Instantiate(Shotgun3, position, Quaternion.identity);
                return new Shotgun3(weapon3, player);
        }
        return null;
    }
}

public class Shotgun1 : Weapon
{
    public Shotgun1 (GameObject weaponObject, GameObject player) : base(weaponObject, player)
    {

    }
    public override void Initialize()
    {
        productName = "Shotgun 1";
    }
}

public class Shotgun2 : Weapon
{
    public Shotgun2(GameObject weaponObject, GameObject player) : base(weaponObject, player)
    {

    }
    public override void Initialize()
    {
        productName = "Shotgun 2";
    }
}

public class Shotgun3 : Weapon
{
    public Shotgun3(GameObject weaponObject, GameObject player) : base(weaponObject, player)
    {

    }
    public override void Initialize()
    {
        productName = "Shotgun 3";
    }
}