using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJumpScript : MonoBehaviour
{
	public static PlayerJumpScript instance;
	
	private Rigidbody2D myBody;
	private Animator anim;
	
	private float forceX;
	private float forceY;
	private float tresholdX = 7f;
	private float tresholdY = 14f;
	
	private bool setPower;
	private bool didJump;
	
	void Awake()
	{
		MakeInstance();
	}
	
	void MakeInstance()
	{
		if (instance == null)
		{
			instance = this;
		}
	}
	
	public void SetPower(bool setPower)
	{
		this.setPower = setPower;
		
		if (setPower)
		{
			Debug.Log("We are setting the power.");
		}
		
		else
		{
			Debug.Log("We are not setting the power.");
		}
		
	}
	

}
