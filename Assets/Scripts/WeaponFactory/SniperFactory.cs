using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SniperFactory : MonoBehaviour, IFactory
{
    [SerializeField] private GameObject Sniper1;
    [SerializeField] private GameObject Sniper2;
    [SerializeField] private GameObject Sniper3;

    public const int SNIPER_TYPE_1 = 0;
    public const int SNIPER_TYPE_2 = 1;
    public const int SNIPER_TYPE_3 = 2;
    public Weapon CreateWeapon(int productType, Vector2 position, GameObject player)
    {
        switch (productType)
        {
            case SNIPER_TYPE_1:
                var weapon1 = Instantiate(Sniper1, position, Quaternion.identity);
                return new Sniper1(weapon1, player);
            case SNIPER_TYPE_2:
                var weapon2 = Instantiate(Sniper2, position, Quaternion.identity);
                return new Sniper2(weapon2, player);
            case SNIPER_TYPE_3:
                var weapon3 = Instantiate(Sniper3, position, Quaternion.identity);
                return new Sniper3(weapon3, player);
        }
        return null;
    }
}

public class Sniper1 : Weapon
{
    public Sniper1(GameObject weaponObject, GameObject player) : base(weaponObject, player)
    {

    }
    public override void Initialize()
    {
        productName = "Sniper 1";
    }
}

public class Sniper2 : Weapon
{
    public Sniper2(GameObject weaponObject, GameObject player) : base(weaponObject, player)
    {

    }
    public override void Initialize()
    {
        productName = "Sniper 2";
    }
}

public class Sniper3 : Weapon
{
    public Sniper3(GameObject weaponObject, GameObject player) : base(weaponObject, player)
    {

    }
    public override void Initialize()
    {
        productName = "Sniper 3";
    }
}