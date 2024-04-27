using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IFactory
{
    Weapon CreateWeapon(int weaponType, Vector2 position, GameObject player);
}
