using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class slateButtonHover : MonoBehaviour
{
    public void selectButton()
    {
        gameObject.GetComponent<Image>().color = Color.gray;
    }
    public void nonSelectButton()
    {
        gameObject.GetComponent<Image>().color = Color.white;
    }
}
