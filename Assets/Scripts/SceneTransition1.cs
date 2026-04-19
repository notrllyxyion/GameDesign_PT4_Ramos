using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition1 : MonoBehaviour
{
    public void SceneTwo()
    {
        SceneManager.LoadScene("Menu");
    }
}
