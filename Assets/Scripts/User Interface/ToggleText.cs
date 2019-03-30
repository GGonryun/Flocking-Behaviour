using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleText : MonoBehaviour
{
    [SerializeField] string on;
    [SerializeField] string off;
    [SerializeField] Text textField;

    public void SetText(bool toggle)
    {
        if(toggle)
        {
            textField.text = on;
        }
        else
        {
            textField.text = off;
        }
    }
}
