using UnityEngine;
using UnityEngine.XR.WSA;

public class SpatialMapping : MonoBehaviour
{
    public static SpatialMapping Instance;
    internal static int PhysicsRaycastMask;
    internal int physicsLayer = 31;
    private SpatialMappingCollider spatialMappingCollider;

    private void Awake()
    {
        Instance = this;
    }

	// Use this for initialization
	void Start () {
        // Initialize and Configure the collider
	    spatialMappingCollider = gameObject.GetComponent<SpatialMappingCollider>();
	    spatialMappingCollider.surfaceParent = this.gameObject;
	    spatialMappingCollider.freezeUpdates = false;
	    spatialMappingCollider.layer = physicsLayer;

        // Define the mask
	    PhysicsRaycastMask = 1 << physicsLayer;

        // set the object as active one
        gameObject.SetActive(true);
	}
}
