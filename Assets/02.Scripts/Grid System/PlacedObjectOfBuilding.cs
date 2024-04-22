using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacedObjectOfBuilding : MonoBehaviour
{
    private PlacedObjectTypeSO placedObjectTypeSO;
    public Vector2Int origin;
    private PlacedObjectTypeSO.Dir dir;

    // building 짓는 함수
    // worldPosition : 터치한 곳의 월드 포지션. placedObjectTypeSO : 설치하고 싶은 building의 타입
    public static PlacedObjectOfBuilding Create(Vector3 worldPosition, Vector2Int origin, PlacedObjectTypeSO.Dir dir,
    PlacedObjectTypeSO placedObjectTypeSO, int cropKindNum)
    {
        GameObject placeObjectTransform =
        Instantiate(
            placedObjectTypeSO.prefab,
            worldPosition,
            Quaternion.Euler(0, placedObjectTypeSO.GetRotationAngle(dir), 0)
        );
        
        // instantiate로 클론될 때 설치된 건물의 Building.cs컴포넌트는 각각 다르게 활성화 된다.
        // 설치된 placedObjectTransfrom의 GetComponent를 해서 Building.cs 컴포넌트를 가져온다.
        // 그리고 그 Component의 함수를 호출하여 x, z값을 넣어준다.
        if (placeObjectTransform.GetComponent<Building>() != null)
        {
            Building bulidingSaveComponent = placeObjectTransform.GetComponent<Building>();
            bulidingSaveComponent.takeX(origin.x);
            bulidingSaveComponent.takeZ(origin.y);
        }
        else if (placeObjectTransform.GetComponent<Farm>() != null)
        {
            Farm farmSaveComponent = placeObjectTransform.GetComponent<Farm>();
            farmSaveComponent.takeX(origin.x);
            farmSaveComponent.takeZ(origin.y);
            farmSaveComponent.GenerateFarm(1, 1, cropKindNum);
            //Debug.Log("CropKind: " + cropKindNum);
        }

        PlacedObjectOfBuilding placedObject = placeObjectTransform.GetComponent<PlacedObjectOfBuilding>();

        placedObject.placedObjectTypeSO = placedObjectTypeSO;
        placedObject.origin = origin;
        placedObject.dir = dir;

        return placedObject;
    }

    public List<Vector2Int> GetGridPositionList()
    {
        return placedObjectTypeSO.GetGridPositionList(origin, dir);
    }

    public void DestroySelf()
    {
        Destroy(gameObject);
    }
}
