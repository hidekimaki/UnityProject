using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class PanelEquipmentsBehavior : MonoBehaviour
{

    public GameObject OverPanel;
    public GameObject DescriptorPanel;
    public GameObject ItemEditorPanel;
    public GameObject prefabItem;
    public GameObject itemsPanel;

    private bool holding = false;

    #region iteminsert objects
    // ========== Item Insert ==========
    private int CurrentItemID;

    public TMP_Text PHInsertItemTitle;
    public TMP_Text PHInsertItemDescription;
    public TMP_Text PHInsertItemAmount;
    public TMP_Text InsertItemTitle;
    public TMP_Text InsertItemDescription;
    public TMP_Text InsertItemAmount;
    #endregion

    private void Start()
    {

        UpdateItemList();
    }

    #region equipment button

    public void ButtonEquipment(int slot)
    {
        holding = true;
        StartCoroutine(CountdownEquipment(1));
    }

    public void onRelease(int slot)
    {
        holding = false;
        if (OverPanel.activeSelf != true)
        {
            EquipmentInfo(slot);
        }
    }

    IEnumerator CountdownEquipment(int seconds)
    {
        int counter = seconds;
        while (counter > 0)
        {
            yield return new WaitForSeconds(1);
            counter--;
        }
        if (holding == true)
        {
            EquipmentChange();
        }
    }

    public void EquipmentInfo(int slot)
    {
        OverPanel.SetActive(true);
        DescriptorPanel.SetActive(true);
        DescriptorPanel.transform.GetChild(0).GetChild(1).GetComponent<TMP_Text>().text = "titulo";
        DescriptorPanel.transform.GetChild(1).GetChild(0).GetComponent<TMP_Text>().text = "teste";
    }

    // Called when holding equipment slot button
    public void EquipmentChange()
    {
        OverPanel.SetActive(true);
        print("equipment change");
    }
    // 
    #endregion

    public void InsertItemOnList()
    {
        Item newItem = new Item(InsertItemTitle.text, InsertItemDescription.text, int.Parse(InsertItemAmount.text));
    }

    public void UpdateItemList()
    {
        foreach (Transform child in itemsPanel.transform)
        {
            GameObject.Destroy(child.gameObject);
        }
        foreach (var item in CharacterManager.characterManager.data.allCharacters[CharacterManager.characterManager.CurrentID].itemList)
        {
            GameObject newItem = Instantiate(prefabItem, itemsPanel.transform);
            newItem.transform.GetChild(0).GetChild(1).GetComponent<TMP_Text>().text = item.name;
            EventTrigger trigger = newItem.GetComponent<EventTrigger>();
            EventTrigger.Entry entry = new EventTrigger.Entry();
            entry.eventID = EventTriggerType.PointerDown;
            entry.callback.AddListener((data) => { OnPointerDownDelegate((PointerEventData)data, item); });
            entry.callback.AddListener(delegate { CallPanelEditItem(item); });
            trigger.triggers.Add(entry);
        }
    }

    public void OnPointerDownDelegate(PointerEventData data, Item i)
    { // Botão direito 
        if (data.pointerId == -2)
        {
            SetValuesItemEditPanel(i);
            ShowPanelEditItem();
        }
    }

    public void CallPanelEditItem(Item i)
    {
        StartCoroutine(Countdown(3));
        SetValuesItemEditPanel(i);
    }

    IEnumerator Countdown(int seconds)
    {
        int counter = seconds;
        while (counter > 0)
        {
            yield return new WaitForSeconds(1);
            counter--;
        }
        ShowPanelEditItem();
    }

    public void ShowPanelEditItem()
    {
        OverPanel.SetActive(true);
        ItemEditorPanel.SetActive(true);
    }

    public void SetValuesItemEditPanel(Item i = null)
    {
        PHInsertItemTitle.text = i.name;
        PHInsertItemDescription.text = i.description;
        PHInsertItemAmount.text = i.amount.ToString();
    }

    public void ButtonOkItemEditorPanel()
    {
        Item newItem = new Item();
        if (InsertItemTitle.text != "")
        {
            newItem.name = InsertItemTitle.text;
        }
        if (InsertItemDescription.text == "")
        {
            newItem.description = InsertItemDescription.text;
        }
        if (InsertItemAmount.text == "")
        {
            newItem.amount = int.Parse(InsertItemAmount.text);
        }
        CharacterManager.characterManager.data.allCharacters[CharacterManager.characterManager.CurrentID].itemList[CurrentItemID] = newItem;
    }


}
