using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJumpScript : MonoBehaviour
{
	public static PlayerJumpScript instance;
	
	private Rigidbody2D myBody;
	private Animator anim;
	
	[SerializeField]
	private float forceX;
	[SerializeField]
	private float forceY;
	
	private float tresholdX = 7f;
	private float tresholdY = 14f;
	
	private bool setPower;
	private bool didJump;
	
	void Awake()
	{
		MakeInstance();
		Initialize();
	}
	
	void Initialize()
	{
		myBody = GetComponent<Rigidbody2D>();
		anim = GetComponent<Animator>();
	}
	
	void Update()
	{
		SetPower();
	}
	
	void MakeInstance()
	{
		if (instance == null)
		{
			instance = this;
		}
	}
	
	void SetPower()
	{
		if (setPower)
		{
			forceX += tresholdX * Time.deltaTime;
			forceY += tresholdY * Time.deltaTime;
			
			if (forceX > tresholdX - .5f)
			{
				forceX = tresholdX - .5f;
			}
			
			if (forceX > tresholdY - .5f)
			{
				forceX = tresholdY - .5f;
			}
			
		}
		
	}
	
	public void SetPower(bool setPower)
	{
		this.setPower = setPower;
		
		if (!setPower)
		{
			Jump();
		}
		
	}
	
	void Jump()
	{
		myBody.velocity = new Vector2 (forceX, forceY);
		forceX = forceY = 0f;
		didJump = true;
	}
	
	void OnTriggerEnter2D(Collider2D target)
	{		
		if (didJump)
		{
			didJump = false;
			if (target.tag == "Platform")
			{
				Debug.Log("Point!");
			}
		}
	}
	

}
