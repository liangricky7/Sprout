using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ChangeSceneCustom : MonoBehaviour
{
    public void MovetoScene(int sceneID)
    {
        SceneManager.LoadScene(sceneID);
    }
}
