using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ShowInfoText : MonoBehaviour
{
    public List<ShowInfoText> showInfoTextsList = new List<ShowInfoText>();
    public TMP_Text infoText;
    bool showInfoText = false;
    public string text;
    public void OnButtonClick()
    {
        showInfoTextsList.AddRange(FindObjectsOfType<ShowInfoText>());
        for (int i = 0; i < showInfoTextsList.Count; i++)
            if(this!=showInfoTextsList[i])
                showInfoTextsList[i].showInfoText = false;
        showInfoText = !showInfoText;
        infoText.text = text;
        infoText.gameObject.SetActive(showInfoText);
        infoText.gameObject.transform.position = this.transform.position + new Vector3(120,-10,0);
        showInfoTextsList.Clear();
        showInfoTextsList.TrimExcess();
    }
}
