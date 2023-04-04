using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class PanelAttributesBehavior : MonoBehaviour
{
    public Image BarraDeVida;

    AllData data;
    private float tempPV = 100;
    private float maxPV = 100;
    public TMP_Text PVmodificator;

    public TMP_Text PVcounter;

    public  void Start()
    {
        tempPV = maxPV;
    }

    public void putnumberinPVMOD(string number){
        PVmodificator.text += number;
    }

    public void modifyPV(int a){
        if(a == 0){
            tempPV+=1;
        }
        if(a == 1){
            tempPV-=1;
        }
                    UpdatePV();

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
        UpdateVisualsPV();
    }

    public void UpdateVisualsPV(){
        float aux = (float)(tempPV/maxPV);
        print(aux);
        BarraDeVida.fillAmount = aux;
    }


}
