using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Slider mySlider;
    public Image full;
    public Image hurt;

    // Start is called before the first frame update
    private void Start()
    {
        AudioManager._instance.PlayMusic();
    }

    void Awake()
    {
        Damageable.globalDamageEvent.AddListener(onHealthChanged);
        Damageable.globalDeathEvent.AddListener(onDeath);
    }

    private void onHealthChanged(GameObject go, float amount)
    {
        float hp = go.GetComponent<Damageable>().hp;
        mySlider.value = hp;
        if (hp > 50)
        {
            full.enabled = true;
            hurt.enabled = false;
        }
        else
        {
            full.enabled = false;
            hurt.enabled = true;
        }
    }

    private void onDeath(GameObject gameObject, float amount)
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
