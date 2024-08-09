using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MARWA
{
    public class PlayerManager : CharacterManager //whatever character the character manager has, player manager will have that too
    {
        PlayerLocomotionManager playerLocomotionManager;
        protected override void Awake()
        {
            base.Awake();

            //do moe stuff, only for player

            playerLocomotionManager = GetComponent<PlayerLocomotionManager>();
        }

        protected override void Update()
        {
            base.Update();

            // handle all of the character's movement...
            playerLocomotionManager.HandleAllMovement();
        }
    }
}

