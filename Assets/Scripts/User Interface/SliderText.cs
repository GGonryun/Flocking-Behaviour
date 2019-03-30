using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class SliderText : MonoBehaviour
{
    [SerializeField] Slider slider;
    [SerializeField] string format;
    [SerializeField] Text textField;

    public void Awake()
    {
        textField.text = string.Format(format, slider.value);
    }

    public void SetText(float value)
    {
        textField.text = string.Format(format, value.ToString("0.00"));
    }
}
