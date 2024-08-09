using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;

namespace MARWA
{
    public class PlayerUIManager : MonoBehaviour
    {
        public static PlayerUIManager instance;


        //header for debugging purposes
        [Header("Network join")] 
        [SerializeField] bool startGameAsClient;

        private void Awake()
        {
            if(instance == null)
            {
                instance = this;
            }

            else
            {
                Destroy(instance);
            }
        }

        private void Start()
        {
            DontDestroyOnLoad(gameObject);
        }

        private void Update()
        {
            if (startGameAsClient)
            {
                startGameAsClient = false;
                NetworkManager.Singleton.Shutdown(); //we must first shut down because we have started as a host during the title screen
                NetworkManager.Singleton.StartClient(); //we then restart as a client
            }
        }
    }
}

