using System;
using UnityEngine;

public class CharacterControl : MonoBehaviour
{
    #region Variables
    /// <summary>
    /// Return true if Character Control Object should be controllable, or false if not.
    /// </summary>
    [Tooltip("Return true if Character Control Object should be controllable, or false if not.")]
    public bool controllable = true;
    /// <summary>
    /// The speed at which this controller moves on the ground.
    /// </summary>
    [Tooltip("The speed at which this controller moves on the ground.")]
    public float groundMovementSpeed = 5f;
    /// <summary>
    /// The time alotted for turn smoothing.
    /// </summary>
    public float turnSmoothTime = 0.1f;
    /// <summary>
    /// The GameObject that holds the aesthetics.
    /// </summary>
    public Transform aestheticsGroup;
    /// <summary>
    /// The Animator attached to the order picker.
    /// </summary>
    public Animator orderPickerAnimator;

    /// <summary>
    /// The Character Controller component attached to this GameObject.
    /// </summary>
    private CharacterController controller;
    /// <summary>
    /// A Vector3 that holds player input values.
    /// </summary>
    private Vector3 inputVector;
    /// <summary>
    /// The turn smooth velocity;
    /// </summary>
    private float turnSmoothVelocity;
    #endregion

    //Runs at the start of the scene.
    void Start()
    {
        controller = GetComponent<CharacterController>();

        controllable = ValidateData();
    }

    /// <summary>
    /// Makes sure all the values in the Unity Editor are valid, otherwise the ability to control this object will be taken away.
    /// </summary>
    /// <returns>
    /// True if data is valid, or false if not.
    /// </returns>
    private bool ValidateData()
    {
        bool output = true;

        if (Mathf.Sign(groundMovementSpeed) == -1)
        {
            Debug.LogError("Ground Movement Speed property cannot be negative.", gameObject);
            output = false;
        }
        if (turnSmoothTime <= 0)
        {
            Debug.LogError("Turn Smooth Time property cannot be less than or equal to Zero.", gameObject);
            output = false;
        }

        return output;
    }

    //Runs every frame in the scene.
    void Update()
    {
        //Is this controller controllable?
        if (controllable)
        {
            //See function
            CalculateInputVector();
            //Run the Ground Movement logic
            GroundMovement(); 
        }
    }

    /// <summary>
    /// Calculates the inputVector variable with player input.
    /// </summary>
    private void CalculateInputVector()
    {
        //GetAxisRaw is used to circumvent input-smoothing
        //.normalized is used to keep the vector's magnitude (the length of the vector) at 1 or less.
        inputVector = new Vector3( Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical")).normalized;
    }

    /// <summary>
    /// This function handles the player ground movement.
    /// </summary>
    private void GroundMovement()
    {
        if (inputVector.magnitude >= float.Epsilon)
        {
            //Move our character controller in accordance with our logic and calculations.
            controller.Move(inputVector * groundMovementSpeed * Time.deltaTime);

            RotateAesthetics(); 
        }

        AnimateCharacter();
    }

    /// <summary>
    /// Animates the player character model.
    /// </summary>
    private void AnimateCharacter()
    {
        orderPickerAnimator.SetFloat("MovementSpeed", inputVector.magnitude);
    }

    /// <summary>
    /// Rotates the aesthetics of the character so that it doesn't mess with the movement direction.
    /// </summary>
    private void RotateAesthetics()
    {
        float targetAngle = Mathf.Atan2(inputVector.x, inputVector.z) * Mathf.Rad2Deg;
        float angle = Mathf.SmoothDampAngle(aestheticsGroup.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);

        aestheticsGroup.rotation = Quaternion.Euler(0f, angle, 0f);
    }
}