using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu]
public class AllData : ScriptableObject
{
    public int CurrentCharacterID;

    public List<Character> allCharacters;
    public ActionList allActions = new ActionList();
    public EquipmentList allEquipment = new EquipmentList();
    public JobList allJobs = new JobList(); 
    public RaceList allRaces = new RaceList();
}
