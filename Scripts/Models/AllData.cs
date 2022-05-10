using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu]
public class AllData : ScriptableObject
{
    public int CurrentCharacterID;

    public ActionList allActions = new ActionList();
    public List<Character> allCharacters;
    public EquipmentList allEquipment = new EquipmentList();

}
