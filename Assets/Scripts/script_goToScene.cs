using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class script_goToScene : MonoBehaviour {

    public string destination;

	public void OnGoToStage()
    {

       SceneManager.LoadScene(destination);

    }
}
