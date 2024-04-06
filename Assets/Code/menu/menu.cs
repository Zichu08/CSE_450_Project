using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace menu
{
    public class menu : MonoBehaviour
    {
        
        public static menu instance;
        public GameObject mainMenu;
        public GameObject optionsMenu;
        public GameObject characterMenu;
        public GameObject helpMenu;
        
        // Methods
        void Awake() {
            instance = this;
            Show();
        }
        
        public void Show() {
            ShowMainMenu();
            gameObject.SetActive(true);
        }

        public void Hide() {
            gameObject.SetActive(false);
        }

        
        void SwitchMenu(GameObject someMenu) {
            // Clean-up Menus
            mainMenu.SetActive(false);
            optionsMenu.SetActive(false);
            characterMenu.SetActive(false);
            helpMenu.SetActive(false);

            // Turn on requested menu
            someMenu.SetActive(true);
        }

        public void ShowMainMenu() {
            SwitchMenu(mainMenu);
        }

        public void ShowOptionsMenu() {
            SwitchMenu(optionsMenu);
        }

        public void ShowCharactorMenu()
        {
            SwitchMenu(characterMenu);
        }

        public void ShowHelpMenu()
        {
            SwitchMenu(helpMenu);
        }
        
        public void LoadCityScene()
        {
            SceneManager.LoadScene("scene_1");
        }
    }
}