using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MenuController : MonoBehaviour
{
   
   /*
    1 Character selection/edit/delete/levelup
    2 Atributes display/ Skills Display/ Resistances display/ Values display
    3 Character class abilities / race abilities
    4 Equipment display / inventory display
   */
   public List<GameObject> Panels;
   public TMP_Text Label;

    public void clearPanels(){
       foreach (var item in Panels)
       {
           item.SetActive(false);
       }
    } 

    public void SetPanelActive(int panel){
        clearPanels();
        if(Panels[panel]){
            Panels[panel].SetActive(true);
        }else{
            print("Panel não existe, id:"+panel);
        }
    }
    
    public void setPanelLabel(string name){
        Label.text = name;
    }

}
