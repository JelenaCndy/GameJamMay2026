using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scenechangerrrr : MonoBehaviour
{
    public string m_sceneName;

    // Start is called before the first frame update
    void Start()
    {
        
    }


    public void Transition()
    {
        SceneManager.LoadScene(m_sceneName);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
