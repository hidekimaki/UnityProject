using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JsonRead : MonoBehaviour
{
    public AllData data;
    public TextAsset jsonfileAction;
    public TextAsset jsonfileEquip;
    public TextAsset jsonfileJob;
    public TextAsset jsonfileRace;
    
    private void Start()
    {
        data.allEquipment = JsonUtility.FromJson<EquipmentList>(jsonfileEquip.text);
        data.allActions = JsonUtility.FromJson<ActionList>(jsonfileAction.text);
        data.allRaces = JsonUtility.FromJson<RaceList>(jsonfileRace.text);
        data.allJobs = JsonUtility.FromJson<JobList>(jsonfileJob.text);

    }

   
   



}

