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

	private ARPointCloudVisualizer _pointScript;

	private ARPlaneVisualizer _planeScript;

	public void ToggleARPanel() {
		_arPanel.SetActive(!_arPanel.activeSelf);
	}

	void Start()
	{
		ARPlaneHandler.returnARPlane += PlaceMap;
		ARPlaneHandler.resetARPlane += ResetPlane;

		_pointScript = _arRoot.GetComponent(typeof(ARPointCloudVisualizer)) as ARPointCloudVisualizer;
		_planeScript = _arRoot.GetComponent(typeof(ARPlaneVisualizer)) as ARPlaneVisualizer;
	}

	void PlaceMap(BoundedPlane plane)
	{
		_pointScript.enabled = false;
		_planeScript.enabled = false;

		var oldMask = _camera.cullingMask;
		var newMask = oldMask & ~(1 << 8);
		_camera.cullingMask = newMask;

		if (!_mapTransform.gameObject.activeSelf)
		{
			_mapTransform.gameObject.SetActive(true);
		}

		_mapTransform.position = plane.center;
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
