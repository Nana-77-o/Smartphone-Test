using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChenge : MonoBehaviour
{
    private static SceneChenge _instance = default;
    public static SceneChenge Instance 
    {
        get
        {
            if(_instance == null)
            {
                var obj = new GameObject("SceneChenge");
                var scene = obj.AddComponent<SceneChenge>();
                _instance = scene;
                DontDestroyOnLoad(obj);
            }
            return _instance;
        }
    
    }
    private void Awake()
    {
        _instance = this;
    }
    public void ChengeScene(string scene )
    {
        SceneManager.LoadScene(scene);
    }
}
