using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    public string SceneName = "None";

    void Start()
    {
        if (SceneName == "None")
        {
            SceneName = SceneManager.GetActiveScene().name;
        }
    }

    public void Load()
    {
        SceneManager.LoadScene(SceneName);
    }
}