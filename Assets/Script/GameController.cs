using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class GameController : MonoBehaviour
{
    [SerializeField] string lvlname;
    

    private void Update()
    {
        tocar();
    }
    void tocar()
    {
        if (Input.GetButtonUp("Fire1"))
        {
            TrocarCena();
        } 
        ;
    }
    public void TrocarCena()
    {
        SceneManager.LoadScene(lvlname);
    } 

    public void Exit()
    {
        Application.Quit();
    }
   
}
