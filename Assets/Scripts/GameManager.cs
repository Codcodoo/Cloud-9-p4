using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
    public Image blackscreen;
    void Start()
    {
        ScreenShow();
    }
    void Update()
    {
        if (Input.GetKey(KeyCode.R)){Restart();}//restart scene for testing
    }
    void ScreenShow()
    {
        blackscreen.gameObject.SetActive(true);
        blackscreen.color = new Color32(0, 0, 0, 100);
        blackscreen.CrossFadeAlpha(0, 5, true);
    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
