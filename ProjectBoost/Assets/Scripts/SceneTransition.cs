using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SceneTransition : MonoBehaviour
{
    [SerializeField] Image startSceneImage;
    [SerializeField] Image endSceneImage;
    [SerializeField] float fltTransitionSpeed = 500;


    //store reference resolution of canvas
    int screenWidth = 1920;
    bool boolTransitionToNextScene = false;
    private void Update()
    {
        StartCurrentScene();
        if (boolTransitionToNextScene)
        {
            TransitionToNextScene();
        }
    }

    public void StartTransitionToNextScene()
    {
        boolTransitionToNextScene = true;
    }

    void TransitionToNextScene()
    {
        RectTransform rectTransform = endSceneImage.GetComponent<RectTransform>();
        if (rectTransform.sizeDelta.x < screenWidth)
        {
            rectTransform.sizeDelta += new Vector2(fltTransitionSpeed * Time.deltaTime, 0);
        }
    }

    void StartCurrentScene()
    {
        RectTransform rectTransform = startSceneImage.GetComponent<RectTransform>();

        if (rectTransform.sizeDelta.x > 0)
        {
            rectTransform.sizeDelta -= new Vector2(fltTransitionSpeed * Time.deltaTime, 0);
        }
    }
}
