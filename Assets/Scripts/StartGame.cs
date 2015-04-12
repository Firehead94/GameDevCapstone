using UnityEngine;
using System.Collections;

public class StartGame : MonoBehaviour {


    [SerializeField]
    private string firstLevel;

    public void loadGame()
    {
        Application.LoadLevel(firstLevel);    
    }
}
