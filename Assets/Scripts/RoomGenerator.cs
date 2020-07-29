using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RoomGenerator : MonoBehaviour
{

    public enum Direction
    {
        up,
        down,
        left,
        right
    };
    public Direction direction;


    [Header("房间信息")]//标题
    public GameObject roomPrefab;
    public int roomNumber;
    public Color startColor, endColor;
    private GameObject endRoom;


    [Header("位置控制")]
    public Transform generatorPoint;
    public float x0ffset;
    public float y0ffset;

    public LayerMask roomLayer;

    public List<GameObject> rooms = new List<GameObject>();

    void Start()
    {
        for (int i = 0; i < roomNumber; i++)
        {
            rooms.Add(Instantiate(roomPrefab, generatorPoint.position, Quaternion.identity));

            //改变point的位置
            ChangePointPos();

        }
        
        rooms[0].GetComponent<SpriteRenderer>().color = startColor;
        
        endRoom = rooms[0];
        foreach(var room in rooms)
        {
            //sqrMagnitude xyz相乘后相加(x*x+y*y+z*z)
            if(room.transform.position.sqrMagnitude > endRoom.transform.position.sqrMagnitude)
            {
                endRoom = room;
            }
        }
        endRoom.GetComponent<SpriteRenderer>().color = endColor;


    }


    void Update()
    {
        if(Input.anyKey)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }



    public void ChangePointPos()
    {
        do
        {
            direction = (Direction)Random.Range(0, 4);

            switch (direction)
            {
                case Direction.up:
                    generatorPoint.position += new Vector3(0, y0ffset, 0);
                    break;

                case Direction.down:
                    generatorPoint.position += new Vector3(0, -y0ffset, 0);
                    break;

                case Direction.left:
                    generatorPoint.position += new Vector3(-x0ffset, 0, 0);
                    break;

                case Direction.right:
                    generatorPoint.position += new Vector3(x0ffset, 0, 0);
                    break;
            }
        }
        while(Physics2D.OverlapCircle(generatorPoint.position, 0.2f, roomLayer));

    }
}
