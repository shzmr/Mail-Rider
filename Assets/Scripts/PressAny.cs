using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressAny : MonoBehaviour {
    bool pressed = false;
    public Canvas menu;
    public Canvas pressAnyText;

    void Start () {
        menu.enabled = false;
    }

    // Update is called once per frame
    void Update () {
        if (Input.anyKeyDown & !pressed) {
            pressed = true;
            pressAnyText.enabled = false;
            //gameObject.SetActive (false);
            StartCoroutine (FadeTo (0.0f, 1.0f));
        }
    }

    IEnumerator FadeTo (float aValue, float aTime) {
        float alpha = transform.GetComponent<Renderer> ().material.color.a;
        for (float t = 0.0f; t < 1.0f; t += Time.deltaTime / aTime) {
            Color newColor = new Color (1, 1, 1, Mathf.Lerp (alpha, aValue, t));
            transform.GetComponent<Renderer> ().material.color = newColor;
            yield return null;

            menu.enabled = true;
        }
    }
}