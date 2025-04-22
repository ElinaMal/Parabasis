using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public PauseMenu pauseMenu;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
   
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
           pauseMenu.gameObject.SetActive(pauseMenu.gameObject.activeSelf);
        }
    }

}

