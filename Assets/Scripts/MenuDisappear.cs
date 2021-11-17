using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class MenuDisappear : MonoBehaviour
{
    public Text gameTxt, startTxt, exitTxt;
    private void OnMouseUp()
    {
        gameTxt.gameObject.SetActive(false);
        startTxt.gameObject.SetActive(false);
        exitTxt.gameObject.SetActive(false);
    }
}
