using UnityEngine;
using UnityARInterface;

public class ARPlaceMapOnPlane : MonoBehaviour
{
	[SerializeField]
	private Transform _mapTransform;

	[SerializeField]
	private Camera _camera;

	[SerializeField]
	private GameObject _arRoot;

	//[SerializeField]
	//private GameObject _arKit;

	void Start()
	{
		ARPlaneHandler.returnARPlane += PlaceMap;
		ARPlaneHandler.resetARPlane += ResetPlane;
	}

	void PlaceMap(BoundedPlane plane)
	{
		if (!_mapTransform.gameObject.activeSelf)
		{
			_mapTransform.gameObject.SetActive(true);
		}

		_mapTransform.position = plane.center;

		var pointScript = _arRoot.GetComponent(typeof(ARPointCloudVisualizer)) as ARPointCloudVisualizer;
		var planeScript = _arRoot.GetComponent(typeof(ARPlaneVisualizer)) as ARPlaneVisualizer;

		//var debugPlane = _arRoot.transform.Find("debugPlanePrefab(Clone)");
		//debugPlane.gameObject.SetActive(false);
		//var planeHandlerScript = _arKit.GetComponent(typeof(ARPlaneHandler)) as ARPlaneHandler;
		//var shaderScript = _arKit.GetComponent(typeof(UpdateShaderCoordinatesByARPlane)) as UpdateShaderCoordinatesByARPlane;

		pointScript.enabled = false;
		planeScript.enabled = false;
		//planeHandlerScript.enabled = false;
		//shaderScript.enabled = false;

		var oldMask = _camera.cullingMask;
		var newMask = oldMask & ~(1 << 8);
		_camera.cullingMask = newMask;
	}

	void ResetPlane()
	{
		_mapTransform.gameObject.SetActive(false);
	}

	private void OnDisable()
	{
		ARPlaneHandler.returnARPlane -= PlaceMap;
	}
}
