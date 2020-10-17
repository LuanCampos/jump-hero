using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerJumpScript : MonoBehaviour
{
	public static PlayerJumpScript instance;
	
	private Rigidbody2D myBody;
	private Animator anim;
	
	[SerializeField]
	private float forceX;
	[SerializeField]
	private float forceY;
	
	private float tresholdX = 6f;
	private float tresholdY = 13f;
	
	private bool setPower;
	private bool didJump;
	private Slider powerBar;
	private float powerBarTreshold = 10f;
	private float powerBarValue = 0f;
	
	void Awake()
	{
		MakeInstance();
		Initialize();
	}
	
	void Initialize()
	{
		powerBar = GameObject.Find("Slider").GetComponent<Slider>();
		myBody = GetComponent<Rigidbody2D>();
		anim = GetComponent<Animator>();
		powerBar.value = powerBarValue;
	}
	
	void Update()
	{
		IsLiveCheck();
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
			
			if (forceX > tresholdX)
			{
				forceX = tresholdX;
			}
			
			if (forceY > tresholdY)
			{
				forceY = tresholdY;
			}
			
			powerBarValue += powerBarTreshold * Time.deltaTime;
			powerBar.value = powerBarValue;
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
		anim.SetBool("Jump", didJump);
		powerBarValue = 0f;
		powerBar.value = powerBarValue;
	}
	
	void IsLiveCheck()
	{
		if (transform.position.y < -6f)
			{
				Debug.Log("Dead.");
				if (GameOverManager.instance != null)
				{
					GameOverManager.instance.GameOverShowPanel();
				}
				Destroy(gameObject);
			}
	}
	
	void OnTriggerEnter2D(Collider2D target)
	{		
		if (didJump)
		{
			didJump = false;
			anim.SetBool("Jump", didJump);
			
			if (target.tag == "Platform")
			{
				if (ScoreManager.instance != null)
				{
					ScoreManager.instance.IncrementScore();
				}
				
				if (GameManager.instance != null)
				{
					GameManager.instance.CreateNewPlatformAndLerp(target.transform.position.x);
				}
			}
			
		}
	}
	

}
