using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    PlayerActions playerInputs;
    Player player;

    private void OnEnable()
    {
        playerInputs.Enable();
    }

    private void Awake()
    {
        playerInputs = new PlayerActions();
        player = GetComponent<Player>();

        playerInputs.Game.WASD.performed += ctx => player.InputMovement = ctx.ReadValue<Vector2>();
    }

    private void OnDisable()
    {
        playerInputs.Disable();
    }
}
