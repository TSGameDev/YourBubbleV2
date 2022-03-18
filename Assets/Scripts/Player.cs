using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    #region Public Variables

    #endregion

    #region Private Variables

    [SerializeField] Camera cameraa;

    [SerializeField] float speed = 10f;

    CharacterController characterController;
    AudioManager audioManager;
    AudioSource audioSource;

    #endregion

    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
        audioManager = GetComponent<AudioManager>();
        audioSource = GetComponent<AudioSource>();
    }

    private void FixedUpdate()
    {
        Gravity();
    }

    public void Movement(Vector2 inputMovement)
    {
        float x = inputMovement.x;
        float z = inputMovement.y;

        Debug.Log($"Forward Movement: {z} Sideway Movement: {x}");

        Vector3 movement = cameraa.transform.right * x + cameraa.transform.forward * z;

        while (movement.magnitude >= 0.1f)
        {
            characterController.Move(movement * speed * Time.deltaTime);
        }
    }

    void Gravity()
    {
        if (!characterController.isGrounded)
        {
            characterController.Move(Physics.gravity * Time.deltaTime);
        }
    }
}
