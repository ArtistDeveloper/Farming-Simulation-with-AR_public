using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Grid<TGridObject>
{
    // EventHandler : 이벤트가 발생했을 때 알려주는 역할 (delegate와 비슷함/ 이벤트는 대리자를 event한정자로 수식해서 만들기때문)
    // event와 EventHandler의 차이는 외부에서 사용할 수 있냐 내부에서 사용할 수 있냐의 차이.
    public event EventHandler<OnGridObjectChangedEventArgs> OnGridObjectChanged;
    public class OnGridObjectChangedEventArgs : EventArgs
    {
        public int x;
        public int z;
    }

    private int width;
    private int height;
    private float cellSize;
    private Vector3 originPosition; //Grid의 시작점이 [0,0]이 아닐수도 있어서 사용하는 변수.
    private TGridObject[,] gridArray;
    private TextMesh[,] debugTextArray;
    private Quaternion planeRotation;
    // private Transform planeTransform;


    // Func<in T1, in T2, in T3, out TResult>(T1 arg1, T2 arg2, T3 arg3)
    // T1: Grid<TGridObject>, T2: int, T3: int, Out Type: TgridObject // 즉 createGridObject는 TgridObject의 타입이자 반환값이다.
    public Grid(int width, int height, float cellSize, Vector3 originPosition, Quaternion planeRotation, Func<Grid<TGridObject>, int, int, TGridObject> createGridObject)
    {
        this.width = width;
        this.height = height;
        this.cellSize = cellSize; //셀 사이즈를 통해 각 인덱스를 땅위에 올리기 위한 WorldPosition을 계산할 수 있다. // 2 (즉 한칸당 size를 2씩 차지함. 그러면 10x10해서 총 100개 들어감) 
        this.originPosition = originPosition;
        this.planeRotation = planeRotation;

        debugTextArray = new TextMesh[width, height]; //World에 뜨는 숫자
        gridArray = new TGridObject[width, height]; // 여기선 int형 배열이 아닌 TgridObject형 배열로 만듬. 즉 인덱스마다 x, y, grid값이 있네 

        for (int x = 0; x < gridArray.GetLength(0); x++)
        {
            for (int z = 0; z < gridArray.GetLength(1); z++)
            {
                // 그리드(자신)과, x, z값을 넣어 GridObject생성자를 호출하고 그렇게 생성된 객체를 girdArray배열에 넣게 된다.
                // 어쨌든 한 반복문 내에서 생성되는 것이니, 각 그리드 셀은 모두 같은 그리드를 가리킨다.
                gridArray[x, z] = createGridObject(this, x, z);
            }
        }

        //
        for (int x = 0; x < gridArray.GetLength(0); x++)
        {
            for (int z = 0; z < gridArray.GetLength(1); z++)
            {
                // debugTextArray[x, z] = UtilsClass.CreateWorldText(gridArray[x, z].ToString(), planeRotation, GetWorldPosition(x, z) + new Vector3(cellSize, 0, cellSize) * 0.5f, 5, Color.white, TextAnchor.MiddleCenter);

                DrawLine(GetWorldPosition(x, z) + new Vector3 (0, 0.355f, 0), GetWorldPosition(x, z + 1)  + new Vector3 (0, 0.355f, 0));
                DrawLine(GetWorldPosition(x, z) + new Vector3 (0, 0.355f, 0), GetWorldPosition(x + 1, z) + new Vector3 (0, 0.355f, 0));
            }
            DrawLine(GetWorldPosition(0, height) + new Vector3 (0, 0.355f, 0) , GetWorldPosition(width, height) + new Vector3 (0, 0.355f, 0) );
            DrawLine(GetWorldPosition(width, 0) + new Vector3 (0, 0.355f, 0) , GetWorldPosition(width, height) + new Vector3 (0, 0.355f, 0));

            //재준이가 신경쓸 파트는 여기까지

            // OnGridObjectChanged Event에 익명함수를 등록하는 것 같음.
            // OnGridObjectChanged += (object sender, OnGridObjectChangedEventArgs eventArgs) =>
            // {
            //     // 호출된 그리드 셀의 to.string함수가 호출되어 debugTextArray.text에 반환된 x, z, tarnsform값을 넣는다.
            //     // debugTextArray[eventArgs.x, eventArgs.z].text = gridArray[eventArgs.x, eventArgs.z]?.ToString();
            // };
        }
        // SetValue(2, 1, 56); //혹시 NullReference가 난다면, TextMesh값이 debugTextArray에 들어가지 않아서 그런 것.
    }

    public float CellSize
    {
        get { return cellSize; }
        set { cellSize = value; }
    }

    //Gird셀의 위치들을 WorldPosition으로 변환시켜주는 작업. 
    public Vector3 GetWorldPosition(int x, int z)
    {
        return new Vector3(x, 0, z) * cellSize + originPosition;        //재준 필요.
    }

    //좌표에 따른 Grid x,y값 반환. Point를 담은 struct를 반환해도 되겠지만 여기서는 out을 사용해봄.
    public void GetXZ(Vector3 worldPosition, out int x, out int z)
    {
        x = Mathf.FloorToInt((worldPosition - originPosition).x / cellSize); //FlootToTint : 버림함수
        z = Mathf.FloorToInt((worldPosition - originPosition).z / cellSize);
    }

    public void SetGridObject(int x, int z, TGridObject value) //SetValue함수였음.
    {
        if (x >= 0 && z >= 0 && x < width && z < height)
        {
            gridArray[x, z] = value;
            TriggerGridObjectChanged(x, z);
        }
    }

    // GridObject에 변경사항이 일어났을 때 알려주는 이벤트핸들러. 이를 통해 DebugTextArray의 값이 변화되어 들어간다.
    public void TriggerGridObjectChanged(int x, int z)
    {
        OnGridObjectChanged?.Invoke(this, new OnGridObjectChangedEventArgs { x = x, z = z });
    }

    //x, y가 아닌 worldPositon을 받는 SetValue함수
    public void SetGridObject(Vector3 worldPosition, TGridObject value) //SetValue함수였음.
    {
        GetXZ(worldPosition, out int x, out int z);
        SetGridObject(x, z, value);
    }

    public TGridObject GetGridObject(int x, int z) // GetValue였음
    {
        if (x >= 0 && z >= 0 && x < width && z < height)
            return gridArray[x, z];
        else
            return default(TGridObject);
    }

    public TGridObject GetGridObject(Vector3 worldPosition) // GetValue였음
    {
        int x, z;
        GetXZ(worldPosition, out x, out z);
        return GetGridObject(x, z);
    }

    public Vector2Int ValidateGridPosition(Vector2Int gridPosition)
    {
        return new Vector2Int(
            Mathf.Clamp(gridPosition.x, 0, width - 1),
            Mathf.Clamp(gridPosition.y, 0, height - 1)
        );
    }

    //라인 그리기
    void DrawLine(Vector3 start, Vector3 end)
    {
        GameObject myLine = new GameObject();
        myLine.transform.position = start;
        myLine.AddComponent<LineRenderer>();
        LineRenderer lineRenderer = myLine.GetComponent<LineRenderer>();
        lineRenderer.material = new Material(Shader.Find("Custom/NewSurfaceShader"));
        lineRenderer.SetWidth(0.05f, 0.05f);
        lineRenderer.SetPosition(0, start);
        lineRenderer.SetPosition(1, end);
    }
}
