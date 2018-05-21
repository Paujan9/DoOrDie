using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

	public void PlayGame()
    {
        SceneManager.LoadScene("Game");
    }

    public void OpenStore()
    {
        SceneManager.LoadScene("Store");
    }
    public void OpenMenu()
    {
        //SavingClothes.instance.UpdateEquipedMeshes();
        SceneManager.LoadScene("Menu");
    }
    public void QuitGame()
    {
        Debug.Log("QUITING...");
        Application.Quit();
    }
}
