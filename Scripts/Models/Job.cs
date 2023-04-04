using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Job
{
    public string name;
    public int id;
    public string description;
}

[System.Serializable]
public class JobList
{
    public Job[] Job;
}