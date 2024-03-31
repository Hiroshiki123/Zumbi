using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UiController : MonoBehaviour
{
    [SerializeField] Text txtabo;
    [SerializeField] Text txttimer;
    [SerializeField] GameObject venceu;
    [SerializeField] GameObject perdeu;
    public static int numabo = 0;
    float tempo, timer;

    // Start is called before the first frame update
    void Start()
    {
        tempo = 30;
    }

    // Update is called once per frame
    void Update()
    {
        txtabo.text = numabo.ToString();
        txttimer.text = timer.ToString();
        tempo -=1*Time.deltaTime;
        timer = tempo;

        if(timer <= 0)
        {
            perdeu.SetActive(true);
        }
        if(numabo == 5)
        {
            venceu.SetActive(true);
        }
    }
}
