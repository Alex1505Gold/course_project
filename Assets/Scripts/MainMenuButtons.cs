using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuButtons : MonoBehaviour
{
    private void OnMouseUp()
    {
        GetComponent<Text>().color = new Color(255, 255, 255);
    }

    private void OnMouseDown()
    {
        GetComponent<Text>().color = new Color(0, 0, 0);
    }
}
