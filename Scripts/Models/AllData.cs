using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu]
public class AllData : ScriptableObject
{
    public int CurrentCharacterID;

    public List<Action> allActions;
    public List<Character> allCharacters;
    public List<Equipment> allEquipment;

}
