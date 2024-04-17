using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace menu {
    public class menu : MonoBehaviour
    {
        public static menu instance;

        // Menus
        public GameObject mainMenu;
        public GameObject optionsMenu;
        public GameObject characterMenu;
        public GameObject helpMenu;
        public GameObject aboutMenu;
        public GameObject controlMenu;
        // public GameObject settingMenu;

        // Selections
        private string selectedScene;
        private string selectedCharacter;

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
            aboutMenu.SetActive(false);
            controlMenu.SetActive(false);

            // Turn on requested menu
            someMenu.SetActive(true);
        }

        public void ShowMainMenu() {
            SwitchMenu(mainMenu);
        }

        public void ShowOptionsMenu() {
            SwitchMenu(optionsMenu);
        }

        public void ShowCharacterMenu() {
            SwitchMenu(characterMenu);
        }

        public void ShowHelpMenu() {
            SwitchMenu(helpMenu);
        }
        
        public void ShowAboutMenu()
        {
            SwitchMenu(aboutMenu);
        }
        
        public void ShowControlMenu()
        {
            SwitchMenu(controlMenu);
        }

        public void SelectCityScene() {
            selectedScene = "scene_1";
            ShowCharacterMenu(); // Move to character selection after choosing the map
        }

        public void SelectBeachScene() {
            selectedScene = "scene_2";
            ShowCharacterMenu(); // Move to character selection after choosing the map
        }
        
        public void SelectForestScene()
        {
            selectedScene = "scene_forest";
            ShowCharacterMenu();
        }
        
        public void SelectLavaScene()
        {
            selectedScene = "scene_lava";
            ShowCharacterMenu();
        }
        
        public void SelectSpaceScene()
        {
            selectedScene = "scene_space";
            ShowCharacterMenu();
        }

        /*public void SelectSoldier() {
            selectedCharacter = "Soldier";
            ShowHelpMenu();
        }

        public void SelectSwordsman() {
            selectedCharacter = "Swordsman";
            ShowHelpMenu();
        }*/

        public void LoadGame() {
            // Example method to load the game with the selected scene and character
            Debug.Log($"Loading {selectedScene} with {selectedCharacter}");
            SceneManager.LoadScene(selectedScene);
        }
    }
}
