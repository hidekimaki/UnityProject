using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JsonRead : MonoBehaviour
{
    public AllData data;
    public TextAsset jsonfileAction;
    public TextAsset jsonfileEquip;
    
    private void Start()
    {
        data.allEquipment = JsonUtility.FromJson<EquipmentList>(jsonfileEquip.text);
        data.allActions = JsonUtility.FromJson<ActionList>(jsonfileAction.text);
    }

   
   



}

