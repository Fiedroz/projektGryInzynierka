using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileController : MonoBehaviour
{
    private List<GameObject> doorList = new List<GameObject>();
    public List<GameObject> roomEnemiesList = new List<GameObject>();

    private System.Random rnd;

    private MapGenerator.RoomType myType;
    public MapGenerator.RoomType MyType
    {
        get
        {
            return myType;
        }
        private set
        {
        }
    }

    private int maxEnemies;
    public int MaxEnemy
    {
        get
        {
            return maxEnemies;
        }
        set
        {
            maxEnemies = System.Math.Abs(value);
        }
    }

    private bool isOpenRoom = false;

    public bool IsOpenRoom
    {
        get { return isOpenRoom; }
        private set { }
    }


    public void AddDoor(GameObject door)
    {
        this.doorList.Add(door);
    }

/*    public void OpenRandomDoor()
    {
        bool buff = false;

        foreach (var item in this.doorList)
        {
            if (!item.GetComponent<DoorController>().openStatus)
            {
                buff = true;
                break;
            }
        }

        if (buff)
        {
            System.Random rnd = new System.Random(System.DateTime.Now.Millisecond);

            while (!this.doorList[rnd.Next(0, this.doorList.Count)].GetComponent<DoorController>().OpenDoor()) { }
            isOpenRoom = true;
        }
    }

    public void CloseALLDoor(bool pernament = false)
    {
        foreach (var door in this.doorList)
        {
            door.GetComponent<DoorController>().CloseDoor();
            door.GetComponent<DoorController>().SetPermCloseStatus(pernament);
        }
    }*/

    public void SpawnEnemies(bool status)
    {
        if (status == false || this.maxEnemies == 0) return;

        //List<GameObject> buffEnemiesColection = EnemiesSystem.EnemiesColection;
        //List<GameObject> buffEnemiesList = EnemiesSystem.EnemiesList;

        //if (buffEnemiesColection.Count == 0) return;

        switch (this.myType)
        {
            case MapGenerator.RoomType.Small:
                for (int i = 0; i < this.rnd.Next(this.maxEnemies + 1); i++)
                {
                    //this.roomEnemiesList.Add(GameObject.Instantiate(buffEnemiesColection[this.rnd.Next(buffEnemiesColection.Count)]));
                    //buffEnemiesList.Add(this.roomEnemiesList[this.roomEnemiesList.Count - 1]);

                    switch (this.rnd.Next(4))
                    {
                        case 0:
                            this.roomEnemiesList[this.roomEnemiesList.Count - 1].transform.SetPositionAndRotation(new Vector3(this.transform.position.x + 9,
                                                                                                                              1,
                                                                                                                              this.transform.position.z),
                                                                                                                              Quaternion.identity);
                            break;
                        case 1:
                            this.roomEnemiesList[this.roomEnemiesList.Count - 1].transform.SetPositionAndRotation(new Vector3(this.transform.position.x - 9,
                                                                                                                              1,
                                                                                                                              this.transform.position.z),
                                                                                                                              Quaternion.identity);
                            break;
                        case 2:
                            this.roomEnemiesList[this.roomEnemiesList.Count - 1].transform.SetPositionAndRotation(new Vector3(this.transform.position.x,
                                                                                                                              1,
                                                                                                                              this.transform.position.z + 9),
                                                                                                                              Quaternion.identity);
                            break;
                        case 3:

                            this.roomEnemiesList[this.roomEnemiesList.Count - 1].transform.SetPositionAndRotation(new Vector3(this.transform.position.x,
                                                                                                                              1,
                                                                                                                              this.transform.position.z - 9),
                                                                                                                              Quaternion.identity);
                            break;
                    }
                }
                break;
            case MapGenerator.RoomType.Meddium:
                for (int i = 0; i < this.rnd.Next(this.maxEnemies + 1); i++)
                {
                    //this.roomEnemiesList.Add(GameObject.Instantiate(buffEnemiesColection[this.rnd.Next(buffEnemiesColection.Count)]));
                    //buffEnemiesList.Add(this.roomEnemiesList[this.roomEnemiesList.Count - 1]);

                    switch (this.rnd.Next(8))
                    {
                        case 0:
                            this.roomEnemiesList[this.roomEnemiesList.Count - 1].transform.SetPositionAndRotation(new Vector3(this.transform.position.x + 20,
                                                                                                                              1,
                                                                                                                              this.transform.position.z + 12),
                                                                                                                              Quaternion.identity);
                            break;
                        case 1:
                            this.roomEnemiesList[this.roomEnemiesList.Count - 1].transform.SetPositionAndRotation(new Vector3(this.transform.position.x + 12,
                                                                                                                              1,
                                                                                                                              this.transform.position.z + 20),
                                                                                                                              Quaternion.identity);
                            break;
                        case 2:
                            this.roomEnemiesList[this.roomEnemiesList.Count - 1].transform.SetPositionAndRotation(new Vector3(this.transform.position.x + 20,
                                                                                                                              1,
                                                                                                                              this.transform.position.z - 12),
                                                                                                                              Quaternion.identity);
                            break;
                        case 3:
                            this.roomEnemiesList[this.roomEnemiesList.Count - 1].transform.SetPositionAndRotation(new Vector3(this.transform.position.x + 12,
                                                                                                                              1,
                                                                                                                              this.transform.position.z - 20),
                                                                                                                              Quaternion.identity);
                            break;
                        case 4:
                            this.roomEnemiesList[this.roomEnemiesList.Count - 1].transform.SetPositionAndRotation(new Vector3(this.transform.position.x - 20,
                                                                                                                              1,
                                                                                                                              this.transform.position.z - 12),
                                                                                                                              Quaternion.identity);
                            break;
                        case 5:
                            this.roomEnemiesList[this.roomEnemiesList.Count - 1].transform.SetPositionAndRotation(new Vector3(this.transform.position.x - 12,
                                                                                                                              1,
                                                                                                                              this.transform.position.z - 20),
                                                                                                                              Quaternion.identity);
                            break;
                        case 6:
                            this.roomEnemiesList[this.roomEnemiesList.Count - 1].transform.SetPositionAndRotation(new Vector3(this.transform.position.x - 20,
                                                                                                                              1,
                                                                                                                              this.transform.position.z + 12),
                                                                                                                              Quaternion.identity);
                            break;
                        case 7:
                            this.roomEnemiesList[this.roomEnemiesList.Count - 1].transform.SetPositionAndRotation(new Vector3(this.transform.position.x - 12,
                                                                                                                              1,
                                                                                                                              this.transform.position.z + 20),
                                                                                                                              Quaternion.identity);
                            break;
                    }
                }
                break;
            case MapGenerator.RoomType.Big:
                for (int i = 0; i < this.rnd.Next(this.maxEnemies + 1); i++)
                {
                    //this.roomEnemiesList.Add(GameObject.Instantiate(buffEnemiesColection[this.rnd.Next(buffEnemiesColection.Count)]));
                    //buffEnemiesList.Add(this.roomEnemiesList[this.roomEnemiesList.Count - 1]);

                    switch (this.rnd.Next(12))
                    {
                        case 0:
                            this.roomEnemiesList[this.roomEnemiesList.Count - 1].transform.SetPositionAndRotation(new Vector3(this.transform.position.x + 25,
                                                                                                                              1,
                                                                                                                              this.transform.position.z + 33),
                                                                                                                              Quaternion.identity);
                            break;
                        case 1:
                            this.roomEnemiesList[this.roomEnemiesList.Count - 1].transform.SetPositionAndRotation(new Vector3(this.transform.position.x + 33,
                                                                                                                              1,
                                                                                                                              this.transform.position.z + 25),
                                                                                                                              Quaternion.identity);
                            break;
                        case 2:
                            this.roomEnemiesList[this.roomEnemiesList.Count - 1].transform.SetPositionAndRotation(new Vector3(this.transform.position.x + 25,
                                                                                                                              1,
                                                                                                                              this.transform.position.z - 33),
                                                                                                                              Quaternion.identity);
                            break;
                        case 3:
                            this.roomEnemiesList[this.roomEnemiesList.Count - 1].transform.SetPositionAndRotation(new Vector3(this.transform.position.x + 33,
                                                                                                                              1,
                                                                                                                              this.transform.position.z - 25),
                                                                                                                              Quaternion.identity);
                            break;
                        case 4:
                            this.roomEnemiesList[this.roomEnemiesList.Count - 1].transform.SetPositionAndRotation(new Vector3(this.transform.position.x - 25,
                                                                                                                              1,
                                                                                                                              this.transform.position.z - 33),
                                                                                                                              Quaternion.identity);
                            break;
                        case 5:
                            this.roomEnemiesList[this.roomEnemiesList.Count - 1].transform.SetPositionAndRotation(new Vector3(this.transform.position.x - 33,
                                                                                                                              1,
                                                                                                                              this.transform.position.z - 25),
                                                                                                                              Quaternion.identity);
                            break;
                        case 6:
                            this.roomEnemiesList[this.roomEnemiesList.Count - 1].transform.SetPositionAndRotation(new Vector3(this.transform.position.x - 25,
                                                                                                                              1,
                                                                                                                              this.transform.position.z + 33),
                                                                                                                              Quaternion.identity);
                            break;
                        case 7:
                            this.roomEnemiesList[this.roomEnemiesList.Count - 1].transform.SetPositionAndRotation(new Vector3(this.transform.position.x - 33,
                                                                                                                              1,
                                                                                                                              this.transform.position.z + 25),
                                                                                                                              Quaternion.identity);
                            break;
                        case 8:
                            this.roomEnemiesList[this.roomEnemiesList.Count - 1].transform.SetPositionAndRotation(new Vector3(this.transform.position.x + 33,
                                                                                                                              1,
                                                                                                                              this.transform.position.z),
                                                                                                                              Quaternion.identity);
                            break;
                        case 9:
                            this.roomEnemiesList[this.roomEnemiesList.Count - 1].transform.SetPositionAndRotation(new Vector3(this.transform.position.x - 33,
                                                                                                                              1,
                                                                                                                              this.transform.position.z),
                                                                                                                              Quaternion.identity);
                            break;
                        case 10:
                            this.roomEnemiesList[this.roomEnemiesList.Count - 1].transform.SetPositionAndRotation(new Vector3(this.transform.position.x,
                                                                                                                              1,
                                                                                                                              this.transform.position.z + 33),
                                                                                                                              Quaternion.identity);
                            break;
                        case 11:
                            this.roomEnemiesList[this.roomEnemiesList.Count - 1].transform.SetPositionAndRotation(new Vector3(this.transform.position.x,
                                                                                                                              1,
                                                                                                                              this.transform.position.z - 33),
                                                                                                                              Quaternion.identity);
                            break;
                    }
                }
                break;
            case MapGenerator.RoomType.Special:
                break;
        }
    }

    public void _setRoomType(MapGenerator.RoomType type)
    {
        this.myType = type;
    }

    public void _addRnd(System.Random rnd)
    {
        this.rnd = rnd;
    }
}
