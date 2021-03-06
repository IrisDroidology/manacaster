﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This is an abstract class that all characters needs to inherit from
/// </summary>
public abstract class Character : MonoBehaviour {

    /// <summary>
    /// The Player's movement speed
    /// </summary>
    [SerializeField]
    private float speed;

    private Animator animator; // Allows the character.cs script to access the player (gameObject) animator module

    /// <summary>
    /// The Player's direction
    /// </summary>
    protected Vector2 direction;

    // Use this for initialization
    protected virtual void Start () {
        animator = GetComponent<Animator>(); // For gameObject "player"
	}
	
	/// <summary>
    /// Update is marked as virtual, so that we can override it in the subclasses
    /// </summary>
	protected virtual void Update ()
    {
        Move();
	}

    /// <summary>
    /// Moves the player
    /// </summary>
    public void Move()
    {
        //Makes sure that the player moves
        transform.Translate(direction * speed * Time.deltaTime);

        if (direction.x != 0 || direction.y != 0) // If the x-direction or y-direction of the game object (e.g player) is not 0, then go to next line and follow instructions ## If it is not 0, the object is moving in some way!
        {
            //Animate's the Player's movement
            AnimateMovement(direction);
        }
        else // if the object is NOT moving ## object/game-object
        {
            {
                animator.SetLayerWeight(1, 0); // Set back to the idle layer
            }
        }


    }

    /// <summary>
    /// Makes the player animate in the correct direction
    /// </summary>
    /// <param name="direction"></param>
    public void AnimateMovement(Vector2 direction)
    {
        animator.SetLayerWeight(1,1); // # inscope.me 1.3 ## Sets the second animator layer (walk_layer - index values python) to the active layer when the key input to walk is found
        
        //Sets the animation parameter so that he faces the correct direction
        animator.SetFloat("x", direction.x); // sets the value of the parameter "x" in the "animator" to the horizontal direction of the player gameObject
        animator.SetFloat("y", direction.y); // Same as above, however sets "y" as the VERTICAL direction
    }
}
