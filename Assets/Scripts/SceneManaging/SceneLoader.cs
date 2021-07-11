using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void LoadScene(string name){
        if(name=="Exit"||name=="Quit"){
            Application.Quit();
        }else{
            SceneManager.LoadScene(name);
        }
    }
}
