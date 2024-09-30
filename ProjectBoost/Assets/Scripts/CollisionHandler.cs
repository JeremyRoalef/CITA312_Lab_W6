using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
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
        Debug.Log("Collision should load the next scene");
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

        //Wait to reload current scene
        yield return new WaitForSeconds(1);
        //Reload the current scene
        SceneManager.LoadScene(intCurrentSceneIndex);
    }
}
