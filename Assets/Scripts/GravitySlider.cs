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
        Physics2D.gravity = new Vector2(0f, slider.value);
        slider.onValueChanged.AddListener((v) => { 
            sliderText.text = v.ToString(); 
            //player.rb.gravityScale=v;
            Physics2D.gravity = new Vector2(0f,v);
        });
    }
}
