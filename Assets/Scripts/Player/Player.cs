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

    #region Get-Set

    Vector2 inputMovement;
    public Vector2 InputMovement { set => inputMovement = value; }

    #endregion

    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
        audioManager = GetComponent<AudioManager>();
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        Movement();
    }

    private void FixedUpdate()
    {
        Gravity();
    }

    public void Movement()
    {
        float x = inputMovement.x;
        float z = inputMovement.y;

        Vector3 movement = cameraa.transform.right * x + cameraa.transform.forward * z;

        if (movement.magnitude >= 0.1f)
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
