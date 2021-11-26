using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Score : MonoBehaviour
{
    [SerializeField] private TMP_Text Text;
    [SerializeField]private int score;
    [SerializeField] private Slider slider;
    private void OnTriggerEnter(Collider coll)
    {
        if (coll.gameObject.TryGetComponent(out Explosion cube))
        {

            slider.value = score++;
            if (slider.value > 30)
                Text.text = "WIN!!!";

            
        }

    }
}
