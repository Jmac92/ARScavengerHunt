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

	[SerializeField]
	private GameObject _arPanel;

	public void ToggleARPanel() {
		_arPanel.SetActive(!_arPanel.activeSelf);
	}

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

		pointScript.enabled = false;
		planeScript.enabled = false;

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
