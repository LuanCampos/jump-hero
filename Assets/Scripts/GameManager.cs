using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	public static GameManager instance;
	
	[SerializeField]
	private GameObject player;
	[SerializeField]
	private GameObject platform;
	
	private float minX = -2.4f;
	private float maxX = 2.4f;
	private float minY = -4.7f;
	private float maxY = -3.7f;
	
	private bool lerpCamera;
	private float lerpTime = 1.5f;
	private float lerpX;

    void Awake()
    {
        MakeInstance();
		CreateInitialPlatforms();
    }

    void MakeInstance()
	{
		if (instance == null)
		{
			instance = this;
		}
	}
	
	void Update()
	{
		if (lerpCamera)
		{
			LerpTheCamera();
		}
	}
	
	void CreateInitialPlatforms()
	{
		Vector3 temp = new Vector3(Random.Range(minX, minX + 1.2f), Random.Range(minY, maxY), 0);
		Instantiate(platform, temp, Quaternion.identity);
		temp.y += 2f;
		Instantiate(player, temp, Quaternion.identity);
		temp = new Vector3(Random.Range(maxX, maxX - 2f), Random.Range(minY, maxY), 0);
		Instantiate(platform, temp, Quaternion.identity);
	}
	
	public void CreateNewPlatformAndLerp(float lerpPosition)
	{
		CreateNewPlatform();
		lerpX = lerpPosition + maxX;
		lerpCamera = true;
	}
	
	void LerpTheCamera()
	{
		float x = Camera.main.transform.position.x;
		x = Mathf.Lerp(x, lerpX, lerpTime * Time.deltaTime);
		Camera.main.transform.position = new Vector3(x, Camera.main.transform.position.y, Camera.main.transform.position.z);
		
		if (Camera.main.transform.position.x >= (lerpX - 0.007f))
		{
			lerpCamera = false;
		}
		
	}
	
	void CreateNewPlatform()
	{
		float cameraX = Camera.main.transform.position.x;
		float newMaxX = (maxX * 2) + cameraX;
		Instantiate(platform, new Vector3(Random.Range(newMaxX, newMaxX - 1.2f), Random.Range(maxY, maxY - 1.2f), 0), Quaternion.identity);
	}
	
	
}
