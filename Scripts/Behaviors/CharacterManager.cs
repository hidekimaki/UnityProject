using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class CharacterManager : MonoBehaviour
{
    public static CharacterManager characterManager;

    public AllData data;

    public int CurrentID;

    private void Awake()
    {
        characterManager = this;
    }

    public void setNameCurrent(string name)
    {
        data.allCharacters[CurrentID].name = name;
    }

    public void setNameCurrent(TMP_Text name)
    {
        data.allCharacters[CurrentID].name = name.text;
    }
    public void setJobCurrent(int jobid)
    {
        data.allCharacters[CurrentID].job = LoadedData.loadedData.allJobs.Job[jobid];
    }
    public void setRaceCurrent(int raceid)
    {
        data.allCharacters[CurrentID].race = LoadedData.loadedData.allRaces.Race[raceid];
    }
    public void setRaceCurrent(Race race)
    {
        data.allCharacters[CurrentID].race = race;
    }

    public void setATBCurrent(int id, int value)
    {
        data.allCharacters[CurrentID].attributes[id] = value;
    }

    public void setATBfromRace()
    {
        for (int i = 0; i < 15; i++)
        {
            data.allCharacters[CurrentID].attributes[i] = data.allCharacters[CurrentID].race.ATB[i];
        }
    }

    public void setATBfromDistribution(int[] values)
    {
        for (int i = 0; i < 5; i++)
        {
            for (int j = 0; j < 3; i++)
            {
                data.allCharacters[CurrentID].attributes[i * j] += values[i];
            }
        }
    }



    public string GetCharacterDescription()
    {
        return data.allCharacters[CurrentID].description;
    }
    public void SetCharacterDescription(string newdesc)
    {
        data.allCharacters[CurrentID].description = newdesc;
    }

    public void SetCharacterDescription(TMP_Text newdesc)
    {
        data.allCharacters[CurrentID].description = newdesc.text;
    }

    public void SetCharacterFlaw(int flawId)
    {
        data.allCharacters[CurrentID].FlawAction = LoadedData.loadedData.allActionsFlaws.Action[flawId];
    }

    public void SetCharacterIdeal(int IdealId)
    {
        data.allCharacters[CurrentID].IdealsAction = LoadedData.loadedData.allActionsIdeals.Action[IdealId];
    }

    public void setRaceAction(int actionID)
    {
        data.allCharacters[CurrentID].raceAction = LoadedData.loadedData.allActions.Action[actionID];

    }

    public void addJobAction(Action action)
    {
        data.allCharacters[CurrentID].JobActions.Add(action);
    }
    public void addJobAction(int actionID)
    {
        data.allCharacters[CurrentID].JobActions.Add(LoadedData.loadedData.allActions.Action[actionID]);
    }

    public string GetCharacterJob()
    {
        return data.allCharacters[CurrentID].job.name;
    }

    public string GetCharacterRace()
    {
        return data.allCharacters[CurrentID].race.name;
    }

    public string GetCharacterFlaw()
    {
        return data.allCharacters[CurrentID].FlawAction.name;
    }

    public string GetCharacterIdeal()
    {
        return data.allCharacters[CurrentID].IdealsAction.name;
    }


}
