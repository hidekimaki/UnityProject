using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PanelCurrentCharacterBehavior : MonoBehaviour
{

    private Character current;
    public GameObject PanelCurrentCharacter;
    public TMP_Text CurrentSelectedCharracter;

    public TMP_Text CurrentJob;
    public TMP_Text CurrentRace;

    public TMP_Text CurrentName;
    public TMP_Text CurrentDescription;

    public TMP_Text CurrentFlaw;
    public TMP_Text CurrentIdeal;
    public TMP_Dropdown teste;


    public GameObject PanelActions;
    public GameObject prefab;

    public void Start()
    {
        UpdateCharacterMenuPanel();
        GenerateDropdownOptions();
    }


    public void SelectCharacterDropdown()
    {
        for (int i = 0; i < CharacterManager.characterManager.data.allCharacters.Count; i++)
        {
            if (CurrentSelectedCharracter.text == CharacterManager.characterManager.data.allCharacters[i].name)
            {
                CharacterManager.characterManager.CurrentID = i;
            }
        }
        print("Set Current id as: " + CharacterManager.characterManager.CurrentID);
        UpdateCharacterMenuPanel();
    }


    public void GenerateDropdownOptions()
    {
        List<string> options = new List<string>();
        foreach (var item in CharacterManager.characterManager.data.allCharacters)
        {
            options.Add(item.name);
        }
        teste.AddOptions(options);
    }

    public void GenerateNewActionList()
    {
        foreach (var item in LoadedData.loadedData.allActions.Action)
        {
            if (item.job == this.current.job.id)
            {
                if (!currentHasAction(item.name))
                {
                    this.ActionButtonGenerator(item);
                }
            }
        }
    }

    private bool currentHasAction(string ActionName)
    {
        foreach (var item in this.current.JobActions)
        {
            if (item.name == ActionName)
            {
                return true;
            }
        }
        return false;
    }


    public void ActionButtonGenerator(Action action)
    {
        GameObject Actiontext = Instantiate(prefab, PanelActions.transform);
        Actiontext.GetComponent<RectTransform>().sizeDelta = new Vector2(950, action.length);
        Actiontext.transform.GetChild(0).GetComponent<TMP_Text>().text = action.description;
        Actiontext.transform.GetChild(1).GetComponent<TMP_Text>().text = action.name;
        Actiontext.transform.GetComponent<Button>().onClick.AddListener(() => CharacterManager.characterManager.addJobAction(action));
        Actiontext.transform.GetComponent<Button>().onClick.AddListener(() => { PanelActions.transform.parent.transform.parent.transform.parent.gameObject.SetActive(false); });
    }


    public void UpdateCharacterMenuPanel()
    {
        this.current = CharacterManager.characterManager.data.allCharacters[CharacterManager.characterManager.CurrentID];

        CurrentJob.text = this.current.job.name;
        CurrentRace.text = this.current.race.name;
        CurrentName.text = this.current.name;
        CurrentDescription.text = this.current.description;
        CurrentFlaw.text = this.current.FlawAction.name;
        CurrentIdeal.text = this.current.IdealsAction.name;
    }


    public void CallNewCharacterPanel(GameObject Panel)
    {
        if (CharacterManager.characterManager.data.allCharacters.Count < 8)
        {
            PanelCurrentCharacter.SetActive(false);
            Panel.SetActive(true);
        }

    }







}
