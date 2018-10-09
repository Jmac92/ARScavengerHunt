using UnityEngine;
using Mapbox.Utils;
using Mapbox.Unity.Map;
using Mapbox.Unity.MeshGeneration.Factories;
using Mapbox.Unity.Utilities;
using System.Collections.Generic;

public class SpawnOnMap : MonoBehaviour
{
    [SerializeField]
    GameObject _mapGameObject;

    [SerializeField]
    AbstractMap _map;

    [SerializeField]
    [Geocode]
    public string[] _locationStrings;
    Vector2d[] _locations;

    [SerializeField]
    float _spawnScale = 100f;

    [SerializeField]
    GameObject _markerPrefab;

    List<GameObject> _spawnedObjects;

    void Start()
    {
        Debug.Log("MAP SCENE INITATING");
        _locations = new Vector2d[_locationStrings.Length];
        _spawnedObjects = new List<GameObject>();

        for (int i = 0; i < _locationStrings.Length; i++)
        {
            var collectedItems = GameManager.Instance.collectedItems;
            foreach (var id in collectedItems) {
                Debug.Log("COLLECTED ITEM: " + id);
            }

            var locationString = _locationStrings[i];
            _locations[i] = Conversions.StringToLatLon(locationString);

            if (!GameManager.Instance.HasItemBeenCollected(i))
            {
                var instance = Instantiate(_markerPrefab);
                instance.transform.SetParent(_mapGameObject.transform);
                instance.transform.localPosition = _map.GeoToWorldPosition(_locations[i], true);
                instance.transform.localScale = new Vector3(_spawnScale, _spawnScale, _spawnScale);
                instance.name = i.ToString();
                _spawnedObjects.Add(instance);
            }
        }
    }

    private void Update()
    {
        int count = _spawnedObjects.Count;
        for (int i = 0; i < count; i++)
        {
            var spawnedObject = _spawnedObjects[i];
            if (spawnedObject != null)
            {
                var location = _locations[i];
                spawnedObject.transform.localPosition = _map.GeoToWorldPosition(location, true);
                spawnedObject.transform.localScale = new Vector3(_spawnScale, _spawnScale, _spawnScale);
                var pos = spawnedObject.transform.localPosition;
                pos.y = 5;
                spawnedObject.transform.localPosition = pos;
            }
        }
    }
}
