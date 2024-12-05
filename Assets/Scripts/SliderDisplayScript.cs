using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SliderDisplayScript : MonoBehaviour
{
    // Start is called before the first frame update
    TMP_Text Text;
    [SerializeField]
    Slider Slider;
    void Start()
    {
        GlobalData.SetRowsHp(Slider);
        Text =GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        Text.text = $"{Text.name}: {Slider.value}";
    }
}
