using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class titleSceneManager : MonoBehaviour
{
    public void OnStartButton()
    {
        SceneManager.LoadScene("BattleDOG");
    }

}
