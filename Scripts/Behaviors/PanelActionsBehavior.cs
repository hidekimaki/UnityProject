using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PanelActionsBehavior : MonoBehaviour
{
    public AllData data;
    public GameObject PanelActions;
    public GameObject prefab;

    public void actionsListGenerator()
    {
        Character current = CharacterManager.characterManager.data.allCharacters[CharacterManager.characterManager.CurrentID];
        foreach (var item in current.JobActions)
        {
            this.ActionButtonGenerator(item);
        }
        this.ActionButtonGenerator(current.FlawAction);
        this.ActionButtonGenerator(current.IdealsAction);



    }

    public void ActionButtonGenerator(Action action)
    {
        GameObject Actiontext = Instantiate(prefab, PanelActions.transform);
        Actiontext.GetComponent<RectTransform>().sizeDelta = new Vector2(950, action.length);
        Actiontext.transform.GetChild(0).GetComponent<TMP_Text>().text = action.description;
        Actiontext.transform.GetChild(1).GetComponent<TMP_Text>().text = action.name;

    }


    public void Start()
    {
        actionsListGenerator();
    }

}
