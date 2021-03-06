/**
 * Copyright 2016 IBM Corp. All Rights Reserved.
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *      http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class exists to animate the octopus GameObject, and is applied to the 
/// OctopusMovementParent GameObject. The Update function will move the Octopus 
/// if it is supposed to be walking. Further work, such as making the Octopus 
/// detect the edge of the surface in the real world, or falling off of a 'real'
/// table onto the floor in the real world, could be done in here.
/// </summary>
public class OctopusMovement : MonoBehaviour
{
	public float walkingSpeed = 0.05f;
    
	private Animator octopusAnimator;

	private bool walking = false;


	private void Start()
	{
		octopusAnimator = GetComponent<Animator>();
	}


	void Update()
	{
		if (walking)
		{
			
			float f = octopusAnimator.GetCurrentAnimatorStateInfo(0).normalizedTime;

            // Loop the animation.
			int frameNumber = Mathf.FloorToInt(f * 321) % 321;

			// In the animation, the Octopus drags itself across the floor. We don't just want the
            // Octopus to glide across... we want it to stop and start based on when the animation is
            // doing the 'drag' parts. These parts are between frames 141 and 190, and after frame 260.
			if ((frameNumber > 141 && frameNumber < 190) || frameNumber > 260)
			{
				transform.position += transform.forward * Time.deltaTime * walkingSpeed;
			}
		}
	}

    /// <summary>
	/// Starts forward walk.
    /// </summary>
	public void StartForwardMotion()
	{
		walking = true;
	}

    /// <summary>
    /// Stops any walking currently happening.
    /// </summary>
	public void StopForwardMotion()
	{
		walking = false;
	}

    /// <summary>
    /// Turns the character.
    /// </summary>
    /// <param name="degrees">Degrees.</param>
    public void Turn(float degrees)
	{
		transform.Rotate(new Vector3(0, degrees, 0));
	}

}
