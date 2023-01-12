using UnityEngine;
using System.Collections;

public class CameraFollowWithBounds : MonoBehaviour
{

	public Transform target;
	public Vector2 Decalage;

	private Bounds bound;

	// Use this for initialization
	void Start()
	{
		// l'objet cameraBounds doit être un game object avec un box collider 2D en mode trigger
		bound = GameObject.Find("cameraBounds").GetComponent<Collider2D>().bounds;
	}

	// Update is called once per frame
	void Update()
	{
		if (target)
		{
			float cameraHeight = (2 * Camera.main.orthographicSize) / 2;
			float cameraWidth = (cameraHeight * Camera.main.aspect);

			Vector3 destination = new Vector3(target.position.x + Decalage.x, target.position.y + Decalage.y, transform.position.z);
			if (bound != null)
			{
				destination = new Vector3(Mathf.Clamp(destination.x, bound.min.x + cameraWidth, bound.max.x - cameraWidth), Mathf.Clamp(destination.y, bound.min.y + cameraHeight, bound.max.y - cameraHeight), destination.z);
			}
			transform.position = destination;
		}
	}
}
