using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndingManager : MonoBehaviour
{
    public bool isFinished;
    public Image backgroundImage;
    public TextMeshProUGUI endingScreenText;
    public TextMeshProUGUI playAgain;
    public float lerpTime;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        LeanTween.init();
        FadeIn();
    }

    void FadeIn()
    {
        if(isFinished == true)
        {
            print("is this working");
            LeanTween.value(backgroundImage.gameObject, backgroundImage.color.a, 1f, lerpTime).setOnUpdate(ImageAlphaChange);
            LeanTween.value(endingScreenText.gameObject, endingScreenText.color.a, 1f, lerpTime).setOnUpdate(TextOne);
            LeanTween.value(playAgain.gameObject, playAgain.color.a, 1f, lerpTime).setOnUpdate(TextTwo);
            isFinished = false;
        }

        if(playAgain.color.a == 1f)
        {
            if (Input.anyKeyDown)
            {
                SceneManager.LoadScene(0);
            }
        }
    }

    void ImageAlphaChange(float a)
    {
        //this sets a new vector with the lerped alpha channel
        var alphaChange = new Vector4(backgroundImage.color.r, backgroundImage.color.g, backgroundImage.color.b, a);

        backgroundImage.color = alphaChange;
    }

    void TextOne(float a)
    {
        var alphaChange = new Vector4(endingScreenText.color.r, endingScreenText.color.g, endingScreenText.color.b, a);

        endingScreenText.color = alphaChange;
    }

    void TextTwo(float a)
    {
        var alphaChange = new Vector4(playAgain.color.r, playAgain.color.g, playAgain.color.b, a);

        playAgain.color = alphaChange;
    }
}
