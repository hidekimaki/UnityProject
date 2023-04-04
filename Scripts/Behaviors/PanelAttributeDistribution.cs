using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class PanelAttributeDistribution : MonoBehaviour
{
    public TMP_Text[] ATBDisplay = new TMP_Text[5];
    public TMP_Text CurrentPoints;

    public string[] CharacterAttributes = { "Corpo", "Mente", "Senso", "Alma", "Social" };

    public int points = 5;
    public int[] tempATB = new int[5];

    public void UpdateCurrentValues()
    {
        for (int i = 0; i < this.ATBDisplay.Length; i++)
        {
            this.ATBDisplay[i].text = this.CharacterAttributes[i] + "\n" + tempATB[i].ToString();
        }
        CurrentPoints.text = this.points.ToString();
    }

    private void Start()
    {
        UpdateCurrentValues();
    }

    public void AddATB(int ATBID)
    {
        if (this.points > 0)
        {
            this.tempATB[ATBID]++;
            this.points--;
        }
        UpdateCurrentValues();
    }

    public void ReduceATB(int ATBID)
    {
        if (tempATB[ATBID] > 0)
        {
            tempATB[ATBID]--;
            this.points++;
        }
        UpdateCurrentValues();
    }


    public void saveATB()
    {
        CharacterManager.characterManager.setATBfromDistribution(this.tempATB);
    }

    public void resetATB()
    {
        for (int i = 0; i < tempATB.Length; i++)
        {
            tempATB[i] = 0;
        }
    }


}