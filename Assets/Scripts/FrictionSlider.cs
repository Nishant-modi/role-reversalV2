using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FrictionSlider : MonoBehaviour
{
    [SerializeField] private Slider slider;
    //[SerializeField] private TextMeshProUGUI sliderText;
    private PhysicsMaterial2D phys;
    public Rigidbody2D[] pm;
    void Start()
    {
        //slider.value = 9;
        foreach (Rigidbody2D i in pm)
        {
            phys = new PhysicsMaterial2D();
            i.sharedMaterial = phys;
            i.sharedMaterial.friction = 10;

            //sliderText.text = i.sharedMaterial.friction.ToString();
            slider.onValueChanged.AddListener((v) => {
                //sliderText.text = v.ToString();
                phys = new PhysicsMaterial2D();
                i.sharedMaterial = phys;
                i.sharedMaterial.friction = v;
            });
        }
        

        

    }
}
