using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mapbox.Unity;
using Mapbox.Unity.Map;
using Mapbox.Unity.Utilities;
using Mapbox.Utils;
using Mapbox.Map;
using Mapbox.Examples;

public class OverviewMap : MonoBehaviour {
    [SerializeField]
    GameObject _mapCanvas;

    [SerializeField]
    GameObject _overviewMapCanvas;

    [SerializeField]
    GameObject _mapGameObject;

    [SerializeField]
    GameObject _overviewMapGameObject;

    [SerializeField]
    GameObject _playerGameObject;

    [SerializeField]
    GameObject _radarPulse;

    [SerializeField]
    AbstractMap _map;

    [SerializeField]
    AbstractMap _overviewMap;

    [SerializeField]
    GameObject _markerPrefab;
    
    [SerializeField]
    float _markerSpawnScale;

    [SerializeField]
    GameObject _playerPrefab;

    [SerializeField]
    GameObject _rotationIcon;

    [SerializeField]
    GameObject _perspectiveIcon;

    Vector2d[] _locations;

    string[] _locationStrings;

    List<GameObject> _spawnedObjects;

    GameObject _playerInstance;

    WaitForSeconds _wait;

    RotateWithLocationProvider _rotationScript;

    CameraSwap _cameraScript;

    Button _rotationButtonScript;

    Button _perspectiveButtonScript;

    public void SnapToCurrentLocation () {
        _overviewMap.UpdateMap(CalculateCentroid(_locations), _overviewMap.InitialZoom);
    }

    public void StorePlayerPosition () {
        Transitions.playerPosition = _map.CenterLatitudeLongitude;
        Transitions.isOverviewActive = true;
    }

    public void EnableOverviewMap () {
        if (_locations == null) {
            return;
        }

        _playerGameObject.transform.localScale = new Vector3(0, 1, 1);
        _radarPulse.SetActive(false);

        _mapCanvas.SetActive(false);
        
        _mapGameObject.SetActive(false);

        _overviewMapGameObject.SetActive(true);
        SnapToCurrentLocation();

        _playerInstance.SetActive(true);

        _overviewMapCanvas.SetActive(true);

        Transitions.rotationSetting = _rotationScript.isRotatable;
        Transitions.playerRotation = _playerGameObject.transform.localRotation;
        if (_rotationScript.isRotatable) {
            _rotationScript.ToggleRotation();
        }

        Transitions.cameraSetting = _cameraScript.isIsoCamera;
        if (!_cameraScript.isIsoCamera) {
            _cameraScript.Swap();
        }
	}

    public void DisableOverviewMap () {
        SyncComponentSettings();

        _overviewMapCanvas.SetActive(false);

        _playerInstance.SetActive(false);

        _overviewMapGameObject.SetActive(false);

        _mapGameObject.SetActive(true);

        _mapCanvas.SetActive(true);

        _playerGameObject.transform.localScale = new Vector3(1, 1, 1);
        _radarPulse.SetActive(true);
    }

	// Use this for initialization
	void Start () {
        StartCoroutine(Initialize());
	}

    IEnumerator Initialize () {
        yield return new WaitForSeconds(0.0001f);

        _rotationScript = _playerGameObject.GetComponent(typeof(RotateWithLocationProvider)) as RotateWithLocationProvider;
        _cameraScript = _playerGameObject.GetComponent(typeof(CameraSwap)) as CameraSwap;
        _rotationButtonScript = _rotationIcon.GetComponent(typeof(Button)) as Button;
        _perspectiveButtonScript = _perspectiveIcon.GetComponent(typeof(Button)) as Button;

        if (Transitions.locations == null) {
            InitializeObjectsFromNewLocations();
            Transitions.locations = _locations;
            Transitions.locationStrings = _locationStrings;
            Transitions.cameraSetting = true;
            Transitions.rotationSetting = true;
        } else {
            _locations = Transitions.locations;
            _locationStrings = Transitions.locationStrings;
            InitializeObjectsFromExistingLocations();
            SyncComponentSettings();
        }

        InitializePlayerInstance();

        InitializeOverviewMap();  

        if (Transitions.isOverviewActive) {
             Transitions.isOverviewActive = false;
             EnableOverviewMap();
         }
    }

    private void SyncComponentSettings () {
        if (_cameraScript.isIsoCamera != Transitions.cameraSetting) {
            _cameraScript.Swap();

            if (!_cameraScript.isIsoCamera) {
                if (_perspectiveButtonScript.active) {
                    _perspectiveButtonScript.Lock();
                }
            } 
        }

        if (_rotationScript.isRotatable != Transitions.rotationSetting) {
            _rotationScript.ToggleRotation();

            if (_rotationScript.isRotatable) {
                _playerGameObject.transform.localRotation = Transitions.playerRotation;
            } else {
                _rotationButtonScript.Lock();
            }
        } else if (_rotationScript.isRotatable) {
            _playerGameObject.transform.localRotation = Transitions.playerRotation;
        }
    }

	private void InitializeObjectsFromNewLocations () {
        _locationStrings = new string[0];
		SpawnOnMap spawnScript = _map.GetComponent(typeof(SpawnOnMap)) as SpawnOnMap;

		if (spawnScript != null) {
		    _locationStrings = spawnScript._locationStrings;
        }
        _locations = new Vector2d[_locationStrings.Length];
        
        _spawnedObjects = new List<GameObject>();
        for (int i = 0; i < _locationStrings.Length; i++) {
            _locations[i] = Conversions.StringToLatLon(_locationStrings[i]);         

            Vector2d randPoint = new Vector2d(CalculateRandomXOffset(_locations[i]), CalculateRandomYOffset(_locations[i]));

            _locations[i] = randPoint;
            
            GameObject instance = Instantiate(_markerPrefab);
            instance.name = _locationStrings[i];
            instance.transform.SetParent(_overviewMapGameObject.transform);
            
            _spawnedObjects.Add(instance);
        }
    }

    private void InitializeObjectsFromExistingLocations () {
        _spawnedObjects = new List<GameObject>();
        for (int i = 0; i < _locations.Length; i++) {       
            GameObject instance = Instantiate(_markerPrefab);
            instance.name = _locationStrings[i];
            instance.transform.SetParent(_overviewMapGameObject.transform);

            _spawnedObjects.Add(instance);
        }
    }

    private void InitializePlayerInstance () {
        _playerInstance = Instantiate(_playerPrefab);
        _playerInstance.transform.SetParent(_overviewMapGameObject.transform);
        _playerInstance.SetActive(false);
    }

    private void InitializeOverviewMap () {
        _overviewMap.Initialize(CalculateCentroid(_locations), _map.AbsoluteZoom);
        _overviewMap.TileProvider.UpdateTileExtent();
        _overviewMapGameObject.SetActive(false);
    }

    private Vector2d CalculateCentroid (Vector2d[] points) {
        Vector2d centroid = Vector2d.zero;
        var numPoints = points.Length;

        foreach(Vector2d point in points) {
            centroid += point;
        }

        centroid /= numPoints;

        return centroid;
    }

    private double CalculateRandomXOffset (Vector2d point) {
        double randX = 0.00;
        if (Random.value > 0.5) {
            randX = point.x + ((double)Random.Range(0, 11) / 111111);
        } else {
            randX = point.x - ((double)Random.Range(0, 11) / 111111);
        }
        return randX;
    }

    private double CalculateRandomYOffset (Vector2d point) {
        var randY = 0.0;
        if (Random.value > 0.5) {
            randY = point.y + (Random.Range(0, 11) / (111111 * Mathf.Cos((float)(point.x * (Mathf.PI / 180)))));
        } else {
            randY = point.y - (Random.Range(0, 11) / (111111 * Mathf.Cos((float)(point.x * (Mathf.PI / 180)))));
        }
        return randY;
    }
	
	// Update is called once per frame
	private void Update () {
        if ((_spawnedObjects != null) && (_overviewMapGameObject.activeSelf)) {
            int count = _spawnedObjects.Count;
            for (int i = 0; i < count; i++)
            {
                var spawnedObject = _spawnedObjects[i];
                var location = _locations[i];
                if (!GameManager.Instance.HasItemBeenCollected(spawnedObject.name)) {
                    spawnedObject.transform.localPosition = Conversions.GeoToWorldPosition(location, _overviewMap.CenterMercator, _overviewMap.WorldRelativeScale).ToVector3xz();
                    spawnedObject.transform.localScale = new Vector3(_markerSpawnScale, _markerSpawnScale, _markerSpawnScale);
                }
            }

            _playerInstance.transform.localPosition = Conversions.GeoToWorldPosition(_map.CenterLatitudeLongitude, _overviewMap.CenterMercator, _overviewMap.WorldRelativeScale).ToVector3xz();
        }
	}
}
