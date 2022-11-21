using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadAmmo : MonoBehaviour
{
    Image bar;
    public Player player;
    float loadtime;
    bool fillbar = false;
    public AudioSource loaded;
    void Start()
    {
        bar = this.GetComponent<Image>();
        loadtime = player.Loadtime;
    }
    private void Update()
    {
        if (player.ammo>0)
        {
            if (fillbar)
            {
                bar.fillAmount += 1 / loadtime * Time.deltaTime;
                if (bar.fillAmount >= 1)
                {
                    loaded.Play();
                    bar.fillAmount = 1;
                    fillbar = false;
                }
            }
        }
    }
    public void LoadBar()
    {
        bar.fillAmount = 0;
        fillbar = true;
    }
}
