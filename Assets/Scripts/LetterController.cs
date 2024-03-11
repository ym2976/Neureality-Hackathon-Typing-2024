using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LetterController : MonoBehaviour
{
    public Presets.Letters letter;

    public Image letterImage;

    // Start is called before the first frame update
    void Start()
    {
        // get Image component from the game object
        letterImage = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {

    }


    public void SetLetterOffColor()
    {
        letterImage.color = Presets.LetterOffColor;
    }

    public void SetLetterOnColor(Color color)
    {
        letterImage.color = color;
    }

    public void SetLetterTrainHintHighlightColor()
    {
        letterImage.color = Presets.LetterTrainHintHighlightColor;
    }

    public void SetLetterPredictionHighlightColor()
    {
        letterImage.color = Presets.LetterPredictionHighlightColor;
    }



}
