using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackToMain : MonoBehaviour
{
    public bool auto = false;
    public void ToMain()
    {
        SceneManager.LoadScene("MenuScene");
    }

    private void Start()
    {
        if (auto)
        {
            StartCoroutine(ReturnAuto());
        }
    }

    IEnumerator ReturnAuto()
    {
        yield return new WaitForSeconds(5);
        ToMain();
    }
}
