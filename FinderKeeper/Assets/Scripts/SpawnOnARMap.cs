using Mapbox.Unity.Map;
using Mapbox.Unity.Utilities;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnOnARMap : MonoBehaviour {

    public GameObject markerPrefab;
    public AbstractMap abstractMap;

    private List<Collectible> _collectibles;

	// Use this for initialization
	void Awake () {
        _collectibles = GameManager.Instance.GetCourseItems();

        SpawnItems();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void SpawnItems() {
        Debug.Log("COLLECTIBLES: " + _collectibles.Count);
        foreach(Collectible item in _collectibles)
        {
            Debug.Log(item.Id + " " + (item.IsCollected) + " " + (item.IsVisibleOnMap) + " " + item.LatLong);
            if(!!item && !item.IsCollected)
            {
                abstractMap.SpawnPrefabAtGeoLocation(markerPrefab, Conversions.StringToLatLon(item.LatLong), null, true, "Item " + item.name);
            }
        }
    }
}
