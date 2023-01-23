using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
		transform.Rotate(new Vector3(15, 30, 45) * Time.deltaTime);
		//deltaTime is a float representing the different in seconds
		//since the last frame update ocurred (dynamically changes its
		//value based on the length of a frame)
    }
}
