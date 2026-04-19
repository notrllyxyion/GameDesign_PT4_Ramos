using UnityEngine;
using UnityEngine.SceneManagement;

public class Scenetransition : MonoBehaviour
{
    public void SceneTwo()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Application Closed");
    }
}
