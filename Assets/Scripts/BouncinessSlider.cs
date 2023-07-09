using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BouncinessSlider : MonoBehaviour
{
    [SerializeField] private Slider bSlider;
    [SerializeField] private TextMeshProUGUI bSliderText;
    [SerializeField] private Slider fSlider;
    [SerializeField] private TextMeshProUGUI fSliderText;
    private PhysicsMaterial2D phys;
    public Rigidbody2D[] pm;
    void Start()
    {
        foreach (Rigidbody2D i in pm)
        {
            phys = new PhysicsMaterial2D();
            i.sharedMaterial = phys;
            i.sharedMaterial.bounciness = 0.5f;
            i.sharedMaterial.friction = 1;

            Debug.Log(i + " "+ i.sharedMaterial + " Bounciness - " + i.sharedMaterial.bounciness);
            Debug.Log(i + " " + i.sharedMaterial + " Friction - " + i.sharedMaterial.friction);

            bSliderText.text = i.sharedMaterial.bounciness.ToString();
            fSliderText.text = i.sharedMaterial.bounciness.ToString();
            bSlider.onValueChanged.AddListener((v) => {
                bSliderText.text = v.ToString();
                //phys = new PhysicsMaterial2D();
                i.sharedMaterial = phys;
                i.sharedMaterial.bounciness = v;
                //Debug.Log(i + " " + i.sharedMaterial + " " + i.sharedMaterial.bounciness);
            });

            fSlider.onValueChanged.AddListener((v) => {
                fSliderText.text = v.ToString();
                //phys = new PhysicsMaterial2D();
                i.sharedMaterial = phys;
                i.sharedMaterial.friction = v;
                //Debug.Log(i + " " + i.sharedMaterial + " " + i.sharedMaterial.friction);
            });
        }
    }
}
