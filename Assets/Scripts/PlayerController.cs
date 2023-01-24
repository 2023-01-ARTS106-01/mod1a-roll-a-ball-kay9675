using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerController : MonoBehaviour
{
    public float speed = 0;
    public TextMeshProUGUI countText;
    //Holds a refernce to the UI text component on the CountText
	//GameObject.
	
	public GameObject winTextObject;

    private Rigidbody rb;
    private int count;
    private int cubeCount = 16; //Total number of cubes in level
    private float movementX;
    private float movementY;
    
    // Start is called before the first frame update
    void Start()
    {
		rb = GetComponent<Rigidbody>();
		count = 0;
		
		winTextObject.SetActive(false);
		SetCountText();
    }

    void OnMove(InputValue movementValue)
    {
		// Takes Vector2 value from 'movementValue', stores in 'movementVector'
		Vector2 movementVector = movementValue.Get<Vector2>();

		movementX = movementVector.x;
		movementY = movementVector.y;
    }

	void SetCountText()
	{
		countText.text = "Count: " + count.ToString();
		if(count >= cubeCount)
		{
			winTextObject.SetActive(true);
		}
	}

    // Constant updates applied before frame drawing (for physics calcs)
    void FixedUpdate()
	{
		Vector3 movement = new Vector3(movementX, 0.0f, movementY);
		rb.AddForce(movement * speed); // Allows movement modification with 'speed' var.
    }
    
    private void OnTriggerEnter(Collider other)
    {
		if(other.gameObject.CompareTag("PickUp"))
		{
			other.gameObject.SetActive(false);
			count = count + 1;
			
			SetCountText();
		}
	}
}
