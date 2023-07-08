using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FrictionSlider : MonoBehaviour
{
    [SerializeField] private Slider slider;
    [SerializeField] private TextMeshProUGUI sliderText;
    private PhysicsMaterial2D phys;
    public Rigidbody2D pm;
    void Start()
    {
        //slider.value = 9;
        phys = new PhysicsMaterial2D();
        pm.sharedMaterial = phys;
        pm.sharedMaterial.friction = 10;

        sliderText.text =pm.sharedMaterial.friction.ToString();
        slider.onValueChanged.AddListener((v) => {
            sliderText.text = v.ToString();
            phys = new PhysicsMaterial2D();
            pm.sharedMaterial = phys;
            pm.sharedMaterial.friction = v;
        });

    }
}
