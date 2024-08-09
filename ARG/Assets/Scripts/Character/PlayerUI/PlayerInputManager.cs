using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

namespace MARWA
{
    public class PlayerInputManager : MonoBehaviour
    {
        public static PlayerInputManager instance; //for input system

        PlayerControls playerControls; 

        [SerializeField] Vector2 movementInput; //for input system


        private void Awake()
        {
            if (instance == null)
            {
                instance = this;
            }
            else
            {
                Destroy(gameObject);
            }

        }

        private void Start() 
        {
            
            DontDestroyOnLoad(gameObject);

            //when the scene changes. run the logic
            SceneManager.activeSceneChanged += OnSceneChange;

            instance.enabled = false;
        }

        private void OnSceneChange(Scene oldScene, Scene newScene)
        {
            //if we are loading into our world scene, enable players controls
            if (newScene.buildIndex == WorldSaveGameManager.instance.GetWorldSceneIndex())
            {
                instance.enabled = true;
            }

            //pthers disable beciz we are at the main menu
            //this is donne so the player foesnt move arount if we enter things like a character creation menu ect
            else
            {
                instance.enabled = false;
            }
        }

        private void OnEnable() //for input system
        {
            if (playerControls == null)
            {
                playerControls = new PlayerControls();

                //when we move the joystick, we read the joystick value, this is from player controls
                playerControls.PlayerMovements.Movement.performed += i => movementInput = i.ReadValue<Vector2>();
            }

            playerControls.Enable();
        }

        private void OnDestroy()
        {
            //if we destroy this object, unsubscribe from ths evvent
            SceneManager.activeSceneChanged -= OnSceneChange;
        }

    }
}

