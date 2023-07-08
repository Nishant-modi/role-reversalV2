using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GravitySlider : MonoBehaviour
{
    [SerializeField] private Slider slider;
    [SerializeField] private TextMeshProUGUI sliderText;
    public CharacterController player;
    void Start()
    {
        slider.onValueChanged.AddListener((v) => { sliderText.text = v.ToString("0.00"); player.rb.gravityScale=v; });
    }
}
