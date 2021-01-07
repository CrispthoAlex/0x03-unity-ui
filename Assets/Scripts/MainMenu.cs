using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    //  load the maze scene when the Play button is pressed
    public void PlayMaze()
    {
        SceneManager.LoadScene(1, LoadSceneMode.Single);
    }
}
