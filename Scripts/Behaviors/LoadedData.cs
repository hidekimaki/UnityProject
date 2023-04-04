using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadedData : MonoBehaviour
{
    public static LoadedData loadedData;
    public ActionList allActions = new ActionList();
    public ActionList allActionsFlaws = new ActionList();
    public ActionList allActionsIdeals = new ActionList();
    public JobList allJobs = new JobList();
    public RaceList allRaces = new RaceList();

    public TextAsset jsonfileAction;
    public TextAsset jsonfileActionFlaws;
    public TextAsset jsonfileActionIdeals;
    public TextAsset jsonfileJob;
    public TextAsset jsonfileRace;
    private void Awake()
    {
        loadedData = this;
        print("Loading player action json");
        this.allActions = JsonUtility.FromJson<ActionList>(jsonfileAction.text);
        print("Load " + this.allActions.Action.Length + " player actions");

        this.allActionsFlaws = JsonUtility.FromJson<ActionList>(jsonfileActionFlaws.text);
        this.allActionsIdeals = JsonUtility.FromJson<ActionList>(jsonfileActionIdeals.text);


        this.allRaces = JsonUtility.FromJson<RaceList>(jsonfileRace.text);
        print("Load " + this.allRaces.Race.Length + " race options");
        this.allJobs = JsonUtility.FromJson<JobList>(jsonfileJob.text);
        print("Load " + this.allJobs.Job.Length + " job options");
    }

}
