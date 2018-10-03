using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mapbox.Unity;
using Mapbox.Unity.Map;
using Mapbox.Unity.Utilities;
using Mapbox.Utils;
using Mapbox.Map;

public class OverviewMap : MonoBehaviour {

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
    GameObject _playerPrefab;

    [SerializeField]
    float _markerSpawnScale;

    Vector2d[] _locations;

    List<GameObject> _spawnedObjects;

    GameObject _playerInstance;

    WaitForSeconds _wait;

    bool _overviewIsActive = false;

    public void ToggleOverviewMap () {
        if (_overviewIsActive) {
            Destroy(_playerInstance);

            _overviewMapGameObject.SetActive(false);
            _mapGameObject.SetActive(true);

            _playerGameObject.transform.localScale = new Vector3(1, 1, 1);
            _radarPulse.SetActive(true);

            _overviewIsActive = false;
        } else {
            _playerGameObject.transform.localScale = new Vector3(0, 1, 1);
            _radarPulse.SetActive(false);

            _playerInstance = Instantiate(_playerPrefab);
            _playerInstance.transform.SetParent(_overviewMapGameObject.transform);
            _playerInstance.transform.localPosition = _overviewMap.GeoToWorldPosition(_map.CenterLatitudeLongitude, true);
           
            _overviewMapGameObject.SetActive(true);
            _mapGameObject.SetActive(false);

            _overviewIsActive = true;
        }
	}

	// Use this for initialization
	void Start () {
        StartCoroutine(Initialize());
	}

    IEnumerator Initialize () {
        yield return new WaitForSeconds(1);

        InitializeObjects();

        InitializeOverviewMap();
    }

	private void InitializeObjects () {
        string[] locationStrings = new string[0];
		SpawnOnMap spawnScript = _map.GetComponent(typeof(SpawnOnMap)) as SpawnOnMap;

		if (spawnScript != null) {
		    locationStrings = spawnScript._locationStrings;
        }
        _locations = new Vector2d[locationStrings.Length];
        
        _spawnedObjects = new List<GameObject>();
        for (int i = 0; i < locationStrings.Length; i++) {
            _locations[i] = Conversions.StringToLatLon(locationStrings[i]);         

            Vector2d randPoint = new Vector2d(CalculateRandomXOffset(_locations[i]), CalculateRandomYOffset(_locations[i]));
            
            var instance = Instantiate(_markerPrefab);
            instance.transform.SetParent(_overviewMapGameObject.transform);
            instance.transform.localPosition = _map.GeoToWorldPosition(randPoint, true);
            instance.transform.localScale = new Vector3(_markerSpawnScale, _markerSpawnScale, _markerSpawnScale);
            _spawnedObjects.Add(instance);
        }
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
                spawnedObject.transform.localPosition = _overviewMap.GeoToWorldPosition(location, true);
                spawnedObject.transform.localScale = new Vector3(_markerSpawnScale, _markerSpawnScale, _markerSpawnScale);
            }
        }
	}
}
