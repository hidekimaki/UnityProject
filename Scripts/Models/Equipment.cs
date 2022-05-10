using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Equipment 
{
    public string name;
    /* Type
        1 - Weapon
        2 - Armor
        3 - Accessorie
    */
    public string type;

    public int ActionId;
}

[System.Serializable]
public class EquipmentList{
    public Equipment[] Equipment;
}