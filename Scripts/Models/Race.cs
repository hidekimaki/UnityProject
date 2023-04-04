using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Race  
{
   public string name;

    public string description;

   public int[] ATB = new int[15];
   
   public int imageID;

   public int bonusAction;

}

[System.Serializable]
public class RaceList{
    public Race[] Race;
}