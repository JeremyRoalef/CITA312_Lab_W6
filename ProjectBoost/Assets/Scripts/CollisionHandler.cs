using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    void OnCollisionEnter(Collision other)
    {
        switch(other.gameObject.tag) {
            case "Dangerous":
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
}
