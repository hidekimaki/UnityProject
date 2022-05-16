using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Race  
{
   public string name;

   public int[] ATB = new int[15];

   public int imageID;

   public string BaseATBDescription(){
        return 
        "Corpo:"    + (int)(ATB[0]  + ATB[1]    + ATB[2])/3     +"\n"+
        "Senso"     + (int)(ATB[3]  + ATB[4]    + ATB[5])/3     +"\n"+
        "Alma"      + (int)(ATB[6]  + ATB[7]    + ATB[8])/3     +"\n"+
        "Mente"     + (int)(ATB[9]  + ATB[10]   + ATB[11])/3    +"\n"+
        "Social"    + (int)(ATB[12] + ATB[13]   + ATB[14])/3;

   }
}

[System.Serializable]
public class RaceList{
    public Race[] Race;
}