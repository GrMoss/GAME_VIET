using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ShowText : MonoBehaviour
{
    public List<TextGroup> textGroups = new List<TextGroup>();
    public List<GameObject> textPosition = new List<GameObject>();

    public void GetTextPopUp(Color textColor, int posIndex, string message = null)
    {
        for (int i = 0; i < textGroups.Count; i++)
        {
            if (!textGroups[i].myObj.activeInHierarchy)
            {
                textGroups[i].myObj.SetActive(true);
                textGroups[i].text.color = textColor;
                textGroups[i].myObj.transform.position = textPosition[posIndex].transform.position;
                textGroups[i].text.text = message;
                StartCoroutine(DisableText(textGroups[i].myObj));
                break;
            }
        }
    }
    IEnumerator DisableText(GameObject textObj)
    {
        yield return new WaitForSeconds(1f);
        textObj.SetActive(false);
    }
}
[System.Serializable]
public class TextGroup
{
    public GameObject myObj;
    public TextMeshProUGUI text;
}
