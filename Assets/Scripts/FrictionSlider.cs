using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FrictionSlider : MonoBehaviour
{
    [SerializeField] private Slider slider;
    [SerializeField] private TextMeshProUGUI sliderText;
    public PhysicsMaterial2D pm;
    void Start()
    {
        slider.onValueChanged.AddListener((v) => { sliderText.text = v.ToString("0.00"); pm.friction = v; });
    }
}
