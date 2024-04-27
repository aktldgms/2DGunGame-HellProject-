using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PistolFactory : MonoBehaviour, IFactory
{
    [SerializeField] private GameObject Pistol1;
    [SerializeField] private GameObject Pistol2;
    [SerializeField] private GameObject Pistol3;

    public const int PISTOL_TYPE_1 = 0;
    public const int PISTOL_TYPE_2 = 1;
    public const int PISTOL_TYPE_3 = 2;
    public Weapon CreateWeapon(int productType, Vector2 position, GameObject player)
    {
        switch (productType)
        {
            case PISTOL_TYPE_1:
                var weapon1 = Instantiate(Pistol1, position, Quaternion.identity);
                return new Pistol1(weapon1, player);
            case PISTOL_TYPE_2:
                var weapon2 = Instantiate(Pistol2, position, Quaternion.identity);
                return new Pistol2(weapon2, player);
            case PISTOL_TYPE_3:
                var weapon3 = Instantiate(Pistol3, position, Quaternion.identity);
                return new Pistol3(weapon3, player);
        }
        return null;
    }
}

public class Pistol1 : Weapon
{
    public Pistol1(GameObject weaponObject, GameObject player) : base(weaponObject, player)
    {

    }
    public override void Initialize()
    {
        productName = "Pistol 1";
        damage = 25;
        speed = 8f;
        ammo = 21;
        magazineSize = 7;
        reloadTime = 3;
        range = 10f;
        bulletCount = 1; // sýnýr 10, çünkü mermi oluþturma dizisi 10 elemanlý!!!
        magazine = 7;
        bullet = Resources.Load<GameObject>("Bullet");
    }
}

public class Pistol2 : Weapon
{
    public Pistol2(GameObject weaponObject, GameObject player) : base(weaponObject, player)
    {

    }
    public override void Initialize()
    {
        productName = "Pistol 2";
        damage = 25;
        speed = 3;
        ammo = 21;
        magazineSize = 7;
        reloadTime = 3;
        range = 5;
        bulletCount = 1;
        magazine = 7;
    }
}

public class Pistol3 : Weapon
{
    public Pistol3(GameObject weaponObject, GameObject player) : base(weaponObject, player)
    {

    }
    public override void Initialize()
    {
        productName = "Pistol 3";
        damage = 25;
        speed = 3;
        ammo = 21;
        magazineSize = 7;
        reloadTime = 3;
        range = 5;
        bulletCount = 1;
        magazine = 7;
    }
}