using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class PanelAttributesBehavior : MonoBehaviour
{
    AllData data;
    private int tempPV = 100;

    public TMP_Text PVmodificator;

    public TMP_Text PVcounter;

    public void putnumberinPVMOD(string number){
        PVmodificator.text += number;
    }

    public void calculate(string operation){
        if(PVmodificator.text != ""){
            if(operation == "-"){
                tempPV -= int.Parse(PVmodificator.text) ;
            }
            if(operation == "+"){
                tempPV += int.Parse(PVmodificator.text) ;
            }
            PVmodificator.text = "";
            UpdatePV();
        }
    }

    public void UpdatePV(){
        PVcounter.text = "PV:100/"+tempPV;
    }

    public void teste(){
        
    }


}
