using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Action
{
    public string name;
    public string cost;
    public int job;
    public int type; // 1 - Active / 2 - Passive
    public int length;
    public string description;

    Action(string _name, string _cost, int _job, int _type, int _length, string _description)
    {
        this.name = _name;
        this.cost = _cost;
        this.job = _job;
        this.type = _type;
        this.length = _length;
        this.description = _description;
    }
}


[System.Serializable]
public class ActionList
{
    public Action[] Action;
}