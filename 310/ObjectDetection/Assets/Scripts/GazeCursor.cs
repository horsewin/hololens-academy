using UnityEngine;

public class GazeCursor : MonoBehaviour
{
    private MeshRenderer meshRenderer;

	// Use this for initialization
	void Start ()
	{
	    meshRenderer = gameObject.GetComponent<MeshRenderer>();

	    SceneOrganiser.Instance.cursor = gameObject;
        gameObject.GetComponent<Renderer>().material.color = Color.green;

        gameObject.transform.localScale = new Vector3(0.01f, 0.01f, 0.01f);
	}
	
	// Update is called once per frame
	void Update ()
	{
	    Vector3 headPosition = Camera.main.transform.position;
	    Vector3 gazeDirection = Camera.main.transform.forward;

	    RaycastHit gazeHitInfo;
	    if (Physics.Raycast(headPosition, gazeDirection, out gazeHitInfo, 30.0f, SpatialMapping.PhysicsRaycastMask))
	    {
	        meshRenderer.enabled = true;
	        transform.position = gazeHitInfo.point;
	        transform.rotation = Quaternion.FromToRotation(Vector3.up, gazeHitInfo.normal);
	    }
	    else
	    {
	        meshRenderer.enabled = false;
	    }
	}
}
