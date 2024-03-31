using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    [SerializeField] GameObject aboboPrefab;
    float tempo= 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        UiController.numabo = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if ((int)tempo > 0.0f)
        {
            tempo = tempo - Time.deltaTime;
        }
        else
        {
            GameObject inimigo = Instantiate(aboboPrefab);
            inimigo.transform.position = new Vector3(Random.Range(-9, 9), 0, Random.Range(-9, 9));
            tempo = 3.0f;
        }
    }
}
