using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Generator : MonoBehaviour
{
    public enum TypeOfGenerator {Observer,Target};
    public TypeOfGenerator generatorType; 
    public GameObject content;
    List<CelestialObject> celestialObjects = new List<CelestialObject>();
    public SwitchCamera switchCamera;
    public List<GameObject> button = new List<GameObject>();
    public Sprite sprite;
    public void Start()
    {
        celestialObjects = Initialize.GetCelestialObjects();
        for(int i=0;i<celestialObjects.Count;i++)
        {
            GameObject obj = new GameObject("Button" + celestialObjects[i].name);
            button.Add(obj);
            button[i].transform.SetParent(content.transform);
            GameObject newText = new GameObject("Text" + celestialObjects[i].name);
            newText.AddComponent<TextMeshProUGUI>();
            TextSetup(newText.GetComponent<TextMeshProUGUI>(),celestialObjects[i].name);
            newText.transform.SetParent(obj.transform);
            obj.AddComponent<Image>();
            ImageSetup(obj.GetComponent<Image>(),i);
            obj.AddComponent<Button>();
            if(generatorType==TypeOfGenerator.Observer)
            {
                obj.AddComponent<ObserverSelector>();
                obj.GetComponent<ObserverSelector>().switchCamera = FindObjectOfType<SwitchCamera>();
                obj.GetComponent<ObserverSelector>().ordIndex = i;
                obj.GetComponent<Button>().onClick.AddListener(obj.GetComponent<ObserverSelector>().OnClickEvent);
            }
            else
            {
                obj.AddComponent<TargetSeletor>();
                obj.GetComponent<TargetSeletor>().switchCamera = FindObjectOfType<SwitchCamera>();
                obj.GetComponent<TargetSeletor>().ordIndex = i;
                obj.GetComponent<Button>().onClick.AddListener(obj.GetComponent<TargetSeletor>().OnClickEvent);
            }
        }
        content.GetComponent<RectTransform>().sizeDelta= new Vector2(0, celestialObjects.Count * 30+5);
    }
    public void TextSetup(TextMeshProUGUI txtObj, string text)
    {
        txtObj.rectTransform.sizeDelta = new Vector2(180, 30);
        txtObj.text = text;
        txtObj.color = Color.black;
        txtObj.alignment = TextAlignmentOptions.Left;
        txtObj.alignment = TextAlignmentOptions.Midline;
        txtObj.fontSize = 30;
    }
    public void ImageSetup(Image img, int ord)
    {
        img.type = Image.Type.Sliced;
        img.sprite = sprite;
        img.rectTransform.sizeDelta = new Vector2(180, 30);
        img.rectTransform.localPosition=new Vector3(91.5f, 15*(celestialObjects.Count-26)-ord*30,0);
    }
}