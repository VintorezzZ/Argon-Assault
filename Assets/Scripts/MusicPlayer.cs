using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicPlayer : MonoBehaviour
{
    void Awake()
    {
        DontDestroyOnLoad(this);
    }

    void Start()
    {
        Invoke(nameof(LoadFirstScene), 1);
    }

    void LoadFirstScene()
    {
        SceneManager.LoadScene(1);
    }
}
