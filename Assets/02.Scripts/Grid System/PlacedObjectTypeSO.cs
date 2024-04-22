using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class PlacedObjectTypeSO : ScriptableObject
{
    public string nameString;
    public GameObject prefab;
    public GameObject preview;
    public int width;
    public int height;

    public enum Dir
    {
        Down,
        Left,
        Up,
        Right,
    }

    public static Dir GetNextDir(Dir dir)
    {
        switch (dir)
        {
            default:
            case Dir.Down: return Dir.Left;
            case Dir.Left: return Dir.Up;
            case Dir.Up: return Dir.Right;
            case Dir.Right: return Dir.Down;
        }
    }

    // 이 함수는 오프셋을 취하므로 예를 들어 클릭하는 위치와 같은
    // 기본 오프셋이 된 다음 전체 너비를 순환하면서 전체 높이를 순환합니다.
    // 그런 다음 목록에 추가하여 오프셋과 x, y를 더한 다음 vector2 int 목록을 반환합니다.
    public List<Vector2Int> GetGridPositionList(Vector2Int offset, Dir dir)
    {
        List<Vector2Int> gridPositionList = new List<Vector2Int>();
        switch (dir)
        {
            default:
            case Dir.Down:
            case Dir.Up:
                for (int x = 0; x < width; x++)
                {
                    for (int y = 0; y < height; y++)
                    {
                        gridPositionList.Add(offset + new Vector2Int(x, y));
                    }
                }
                break;
            case Dir.Left:
            case Dir.Right:
                for (int x = 0; x < height; x++)
                {
                    for (int y = 0; y < width; y++)
                    {
                        gridPositionList.Add(offset + new Vector2Int(x, y));
                    }
                }
                break;
        }
        return gridPositionList;
    }

    public int GetRotationAngle(Dir dir)
    {
        switch(dir)
        {
            default:
            case Dir.Down: return 0;
            case Dir.Left: return 90;
            case Dir.Up: return 180;
            case Dir.Right: return 270;
        }
        // switch(dir)
        // {
        //     default:
        //     case Dir.Down: return 180;
        //     case Dir.Left: return 270;
        //     case Dir.Up: return 0;
        //     case Dir.Right: return 90;
        // }
    }

    // Left: 0, width인데, pivot이 오브젝트 위에 있어서 그냥 오브젝트만 돌리고 설치시키면 오브젝트는
    // 그리드의 밑부분에 설치된 것 처럼 보이는데 사실 위의 영역을 먹고 있음. 그래서 width를 통해 
    // 오브젝트의 가로만큼 offset을 위로 올려준만큼 설치하게 되면, 건물이 잘 설치됨.
    public Vector2Int GetRotationOffset(Dir dir)
    {
        switch (dir)
        {
            default:
            case Dir.Down: return new Vector2Int(0, 0);
            case Dir.Left: return new Vector2Int(0, width);
            case Dir.Up: return new Vector2Int(width, height);
            case Dir.Right: return new Vector2Int(height, 0);
        }
    }
}
