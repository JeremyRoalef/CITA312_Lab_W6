using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] AudioClip crashSFX;
    [SerializeField] AudioClip winSFX;

    


    void OnCollisionEnter(Collision other)
    {
        switch(other.gameObject.tag) {
            case "Dangerous":
                ReloadScene();
                KillPlayer();
                break;
            case "Fuel":
                RefuelPlayer();
                break;
            case "Finish":
                LoadNextScene();
                break;
            default:
                //Do nothing
                break;
        }
    }

    //Method to kill player
    void KillPlayer()
    {
        GetComponent<Movement>().enabled = false;
        AudioSource audioSource = GetComponent<AudioSource>();
        audioSource.Stop();
        audioSource.loop = false;
        audioSource.clip = crashSFX;
        audioSource.Play();
        Debug.Log("Collision should kill player");
    }

    //Method to refuel player's fuel value
    void RefuelPlayer()
    {
        Debug.Log("Collision should refuel player");
    }

    //Method to load the next scene
    void LoadNextScene()
    {
        GetComponent<Movement>().enabled = false;
        AudioSource audioSource = GetComponent<AudioSource>();
        audioSource.Stop();
        audioSource.loop = false;
        audioSource.clip = winSFX;
        audioSource.Play();
        Debug.Log("Collision should load next scene");
        StartCoroutine(WaitToLoadNextScene());
    }
    
    //Method to load the current scene
    void ReloadScene()
    {
        //Start the coroutine to reload the current scene
        StartCoroutine(WaitToReloadScene());
    }

    //IEnumerator to wait to reload the current scene
    IEnumerator WaitToReloadScene()
    {
        int intCurrentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        //Wait to start transition
        yield return new WaitForSeconds(1);
        GameObject sceneCanvas = GameObject.FindGameObjectWithTag("TransitionCanvas");
        sceneCanvas.GetComponent<SceneTransition>().StartTransitionToNextScene();

        //Wait to reload current scene
        yield return new WaitForSeconds(1);
        //Reload the current scene
        SceneManager.LoadScene(intCurrentSceneIndex);
    }

    //IEnumerator to wait to load the next scene
    IEnumerator WaitToLoadNextScene()
    {
        int intNextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;

        //Wait to start transition
        yield return new WaitForSeconds(1);
        GameObject sceneCanvas = GameObject.FindGameObjectWithTag("TransitionCanvas");
        sceneCanvas.GetComponent<SceneTransition>().StartTransitionToNextScene();

        //Wait to load next scene
        yield return new WaitForSeconds(1);

        //Determine if there is a next scene in build
        bool boolThereIsNextScene = intNextSceneIndex < SceneManager.sceneCountInBuildSettings;

        //If there's a next scene in build, load it
        if (boolThereIsNextScene)
        {
            SceneManager.LoadScene(intNextSceneIndex);
        }
        //Otherwise, restart game (scene at index 0)
        else
        {
            SceneManager.LoadScene(0);
        }
    }
}
