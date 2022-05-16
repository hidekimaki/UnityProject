using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Job 
{
    public string name;
   
    public string description;
    /* ActionID
        Unlocked by levels in class
    */
    public int[] ActionId = new int[10];


}

[System.Serializable]
public class JobList{
    public Job[] Job;
}