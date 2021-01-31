using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuUI : MonoBehaviour {
    public UnityEngine.Video.VideoPlayer vp;
    float time;
    public Canvas canvas;
    public GameObject background;

    void Start () {
        if (vp != null)
            vp.Pause ();
    }

    public void BackToMainMenu () {
        SceneManager.LoadScene ("MenuScene");
    }

    public void newGameSelect () {
        vp.Play ();
        canvas.enabled = false;
        background.SetActive (false);
        StartCoroutine (videoPlay ());

    }

    IEnumerator videoPlay () {
        yield return new WaitForSeconds ((float) vp.length);

        SceneManager.LoadScene ("GameScene");
    }

    public void settingsSelect () {
        SceneManager.LoadScene("SettingsScene");
    }

    public void creditsSelect () {
        SceneManager.LoadScene("CreditsScene");
    }
}