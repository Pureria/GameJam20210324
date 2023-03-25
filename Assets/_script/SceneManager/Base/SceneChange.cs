using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    [SerializeField] protected string sceneName;

    public void ClickSceneChange()
    {
        SceneManager.LoadScene(sceneName);
    }

}
