using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelCharacterBehavior : MonoBehaviour
{
    public AllData data;

    public ScrollRect ScrollablePanel;
    public List<Sprite> JobImages;
    public List<Sprite> RaceImages;
    public List<Sprite> EquipImages;
    public GameObject PanelRaceSelection;
    public GameObject PanelJobSelection;
    public GameObject PanelEquipSelection;

    public GameObject prefabButton;

    private void Start()
    {
        print(GenerateRaces());
        print(GenerateJob());
    }
    public string GenerateRaces(){
        if(data.allRaces.Race.Length<0){return "Error loading races option: Empty list";}
        foreach (var item in data.allRaces.Race)
        {
            GameObject button = Instantiate(prefabButton, PanelRaceSelection.transform);
            button.transform.GetChild(0).GetComponent<Image>().sprite = RaceImages[item.imageID] ;
            button.GetComponent<Button>().onClick.AddListener(delegate {changePanel(PanelRaceSelection,PanelJobSelection);});
            button.transform.GetChild(1).GetChild(0).GetComponent<Text>().text = item.name;
            button.transform.GetChild(1).GetChild(1).GetComponent<Text>().text = item.BaseATBDescription();
        }
        return "Loaded all Character Race options";
    }
   

    public void changePanel(GameObject current, GameObject next){
        ScrollablePanel.content = next.GetComponent<RectTransform>();
        current.SetActive(false);
        next.SetActive(true);
    }


    public string GenerateJob(){
        if(data.allRaces.Race.Length<0){return "Error loading job option: Empty list";}
        foreach (var item in data.allJobs.Job)
        {
            GameObject button = Instantiate(prefabButton, PanelJobSelection.transform);
            button.transform.GetChild(1).GetChild(0).GetComponent<Text>().text = item.name;
            button.transform.GetChild(1).GetChild(1).GetComponent<Text>().text = item.description;
        }

        return "Loaded all Character Job options";
    }
    public string GenerateEquip(){
        if(data.allRaces.Race.Length<0){return "Error loading equip option: Empty list";}
        foreach (var item in data.allJobs.Job)
        {
            GameObject button = Instantiate(prefabButton, PanelEquipSelection.transform);
            button.transform.GetChild(1).GetChild(0).GetComponent<Text>().text = item.name;
            button.transform.GetChild(1).GetChild(1).GetComponent<Text>().text = item.description;
        }

        return "Loaded all Character Equip options";
    }

    public void SetCharacterJob(int id){
        data.allCharacters[data.CurrentCharacterID].job = data.allJobs.Job[id];
    }
    public void SetCharacterRace(int id){
        data.allCharacters[data.CurrentCharacterID].race = data.allRaces.Race[id];
    }

    
}
