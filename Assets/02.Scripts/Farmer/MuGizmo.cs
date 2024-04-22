using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MuGizmo : MonoBehaviour
{
    public enum Type { NORMAL, WAYPOINT }
    private const string wayPointFile = "Famer";
    public Type type = Type.NORMAL;

    public Color _color = Color.yellow;
    public float _radius = 0.1f;

    private void OnDrawGizmos()
    {
        if (type == Type.NORMAL)
        {
            //기즈모 색상 변경
            Gizmos.color = _color;
            //구체 모양의 기즈모 생성. 인자는 (생성위치, 반지름)
            Gizmos.DrawSphere(transform.position, _radius);
        }
        else
        {
            //기즈모 색상 설정
            Gizmos.color = _color;
            //Enemy 이미지 파일을 표시
            Gizmos.DrawIcon(transform.position + Vector3.up * 1.0f, wayPointFile, true);
            Gizmos.DrawWireSphere(transform.position, _radius);

        }
    }
        

}
