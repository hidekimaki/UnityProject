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
    public GameObject PanelCharacterSelection;
    public GameObject PanelCharacterCreation;
    public GameObject prefabButton;

    public void SelectAsCurrent(int id){
        data.CurrentCharacterID = id;
        print("Set Current id as: " + id);
    }

    public void CreationCharacter(){
        PanelCharacterSelection.SetActive(false);
        PanelCharacterCreation.SetActive(true);
    }

    IEnumerator Countdown(int seconds) {
        print("Start Coroutine");
        int counter = seconds;
        while (counter > 0) {
            yield return new WaitForSeconds (1);
            counter--;
        }
        CreationCharacter();
    }

    public void StartTimerCharacterCreationButton(){
        
        StartCoroutine(Countdown(3));
    }



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
            button.GetComponent<Button>().onClick.AddListener(delegate {SetCurrentCharacterRace(item);});
            button.transform.GetChild(1).GetChild(0).GetComponent<Text>().text = item.name;
            button.transform.GetChild(1).GetChild(1).GetComponent<Text>().text = item.description;
        }
        return "Loaded all Character Race options";
    }
   
    public void changePanel(GameObject current, GameObject next){
        ScrollablePanel.content = next.GetComponent<RectTransform>();
        current.SetActive(false);
        next.SetActive(true);
    }

    public void SetCurrentCharacterEquipment(int slot,int Equipid){
       data.allCharacters[data.CurrentCharacterID].equipment[slot] = data.allEquipment.Equipment[Equipid]; 
    }

    public void SetCurrentCharacterRace(Race race){
        data.allCharacters[data.CurrentCharacterID].race = race;
    }

    public void SetCurrentCharacterJob(Job job){
        data.allCharacters[data.CurrentCharacterID].job = job;
    }


    public string GenerateJob(){
        if(data.allRaces.Race.Length<0){return "Error loading job option: Empty list";}
        foreach (var item in data.allJobs.Job)
        {
            GameObject button = Instantiate(prefabButton, PanelJobSelection.transform);
            button.GetComponent<Button>().onClick.AddListener(delegate {changePanel(PanelJobSelection,PanelEquipSelection);});
            button.GetComponent<Button>().onClick.AddListener(delegate {SetCurrentCharacterJob(item);});
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

    public void SetCharacterEquipment(int setId){
        switch (setId)
        {
            case 0: 
                //Nothing
                break;
            case 1:
                //Axe - Leather armor
                break;
            case 2:
                //Club - Leather armor
                break;
            case 3:
                //Dagger - Cloth armor
                break;
            default:
                break;
        }

    }    
}
