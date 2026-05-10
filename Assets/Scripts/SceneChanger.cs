using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    [SerializeField] private string sceneName;

    // Button function
    public void ChangeScene()
    {
        SceneManager.LoadScene(sceneName);
    }

    // ESC key support
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(sceneName);
        }
    }
}