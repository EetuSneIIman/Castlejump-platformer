using UnityEngine;
using UnityEngine.UI;

public class DestroyFarObjects : MonoBehaviour
{

	// Reference
	GameObject Player;

	// Calculated distance value
	public float playerY;
	public float chunkY;

	void Awake()
	{
		Player = GameObject.Find("Player");
	}

	// Update is called once per frame
	private void Update()
	{

		playerY = Player.transform.position.y;
		chunkY = transform.localPosition.y;

		if (chunkY + 50 < playerY)
		{
			Debug.Log("<color=red>DestroyFarObjects: </color>Chunk destroyed");
			Destroy(gameObject);
		}
	}
}