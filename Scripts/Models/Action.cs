using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Action 
{
    public string name;

    // Type 1 - Battle Action
    // Type 2 - Exploration Action
    public int type;
    public string description;



}


[System.Serializable]
public class ActionList{
    public Action[] Action;
}