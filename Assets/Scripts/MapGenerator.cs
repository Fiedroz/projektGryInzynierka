using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MapGenerator : MonoBehaviour
{
    /// Size Rooms/Frame/Seed
    public Vector2Int FrameSize = new Vector2Int(5, 11);
    public Vector2 RoomSize;
    public int Seed;
    public byte ChanceGrowRoom = 115; // max 255

    /// Normal rooms (room to generate)
    public GameObject[] SmallRoom;
    public GameObject[] MeddiumRoom;
    public GameObject[] BigRoom;

    /// Max Enemy on room
    public int MaxEnemiesSmallRoom;
    public int MaxEnemiesMeddiumRoom;
    public int MaxEnemiesBigRoom;

    /// Specjal rooms (start,pc,reactor)
    public GameObject StartRoom;
    public GameObject MiddleRoom;
    public GameObject EndRoom;

    public Material wallMaterial;
    public GameObject Door;
    public GameObject gruz;


    //[HideInInspector]
    //public bool generatedRooms = false;

    protected FrameCell[,] frame;
    public List<GameObject> rooms = new List<GameObject>();
    protected System.Random rnd;

    public enum RoomType
    {
        Small,
        Meddium,
        Big,
        Special
    }

    protected struct FrameCell
    {
        public RoomType Type;
        public int Index;
        public bool exist;

        public FrameCell(RoomType type, int index, bool exist = false)
        {
            this.Type = type;
            this.Index = index;
            this.exist = exist;
        }
    }

    void Start()
    {
        this.rnd = new System.Random(Seed);

        if (this.FrameSize.x < 5 && this.FrameSize.x < 11)
        {
            this.FrameSize = new Vector2Int(5, 11);
        }
        else
        {
            if (this.FrameSize.x < 5)
            {
                this.FrameSize = new Vector2Int(5, this.FrameSize.y);
            }
            else if (this.FrameSize.y < 11)
            {
                this.FrameSize = new Vector2Int(this.FrameSize.x, 11);
            }
        }

        frame = new FrameCell[this.FrameSize.x, this.FrameSize.y];

        for (int y = 0; y < this.FrameSize.y; y++)
        {
            for (int x = 0; x < this.FrameSize.x; x++)
            {
                this.frame[x, y] = new FrameCell(RoomType.Small, 0);
            }
        }

        this.generate();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void generate()
    {
        this.loadFrame();
        this.generateFrame();
        this.generateDoor();
        this.generateBorderMAP();
        this.generateGruz();
        //GetComponent<NavMeshSurface>().BuildNavMesh();
        this.enemiesSpawn();
    }

    void loadFrame()
    {
        // StartRoom
        for (int y = 0; y < 4; y++)
        {
            for (int x = 0; x < 4; x++)
            {
                this.frame[Convert.ToInt32((this.FrameSize.x - 1) / 2) - 1 + x,
                           y] = new FrameCell(RoomType.Special, 1);
            }
        }

        // MiddleRoom
        for (int y = 0; y < 4; y++)
        {
            for (int x = 0; x < 4; x++)
            {
                this.frame[Convert.ToInt32((this.FrameSize.x - 1) / 2) - 1 + x,
                           Convert.ToInt32((this.FrameSize.y - 1) / 2) - 1 + y] = new FrameCell(RoomType.Special, 2);
            }
        }

        // EndRoom
        for (int y = 0; y < 4; y++)
        {
            for (int x = 0; x < 4; x++)
            {
                this.frame[Convert.ToInt32((this.FrameSize.x - 1) / 2) - 1 + x,
                           this.FrameSize.y - 4 + y] = new FrameCell(RoomType.Special, 3);
            }
        }

        // Other
        int numberRoom = 4;
        int buffRoomSize;

        for (int y = 0; y < this.FrameSize.y; y++)
        {
            for (int x = 0; x < this.FrameSize.x; x++)
            {
                if (this.frame[x, y].Index == 0)
                {
                    buffRoomSize = 0;
                    do
                    {
                        buffRoomSize++;
                    } while (this.rnd.Next(0, 255) <= ChanceGrowRoom
                          && x + buffRoomSize < this.FrameSize.x
                          && y + buffRoomSize < this.FrameSize.y
                          && this.frame[x + buffRoomSize, y].Index == 0
                          && this.frame[x, y + buffRoomSize].Index == 0
                          && this.frame[x + buffRoomSize, y + buffRoomSize].Index == 0
                          && buffRoomSize < 3);


                    switch (buffRoomSize)
                    {
                        case 1:
                            this.frame[x, y] = new FrameCell(RoomType.Small, numberRoom);
                            break;

                        case 2:
                            this.frame[x, y] = new FrameCell(RoomType.Meddium, numberRoom);
                            this.frame[x + 1, y] = new FrameCell(RoomType.Meddium, numberRoom);
                            this.frame[x, y + 1] = new FrameCell(RoomType.Meddium, numberRoom);
                            this.frame[x + 1, y + 1] = new FrameCell(RoomType.Meddium, numberRoom);
                            x++;
                            break;

                        case 3:
                            this.frame[x, y] = new FrameCell(RoomType.Big, numberRoom);
                            this.frame[x + 1, y] = new FrameCell(RoomType.Big, numberRoom);
                            this.frame[x + 2, y] = new FrameCell(RoomType.Big, numberRoom);
                            this.frame[x, y + 1] = new FrameCell(RoomType.Big, numberRoom);
                            this.frame[x, y + 2] = new FrameCell(RoomType.Big, numberRoom);
                            this.frame[x + 1, y + 1] = new FrameCell(RoomType.Big, numberRoom);
                            this.frame[x + 1, y + 2] = new FrameCell(RoomType.Big, numberRoom);
                            this.frame[x + 2, y + 1] = new FrameCell(RoomType.Big, numberRoom);
                            this.frame[x + 2, y + 2] = new FrameCell(RoomType.Big, numberRoom);
                            x += 2;
                            break;
                    }
                    numberRoom++;
                }
                else
                {
                    switch (this.frame[x, y].Type)
                    {
                        case RoomType.Small:
                            break;

                        case RoomType.Meddium:
                            x += 1;
                            break;

                        case RoomType.Big:
                            x += 2;
                            break;

                        case RoomType.Special:
                            x += 3;
                            break;
                    }
                }
            }
        }
    }

    void generateFrame()
    {
        this.rooms.Add(null);
        this.rooms.Add(null);
        this.rooms.Add(null);


        for (int y = 0; y < this.FrameSize.y; y++)
        {
            for (int x = 0; x < this.FrameSize.x; x++)
            {
                if (!this.frame[x, y].exist)
                {
                    switch (this.frame[x, y].Type)
                    {
                        case RoomType.Small:
                            generateSmallRoom(ref x, ref y);
                            break;

                        case RoomType.Meddium:
                            generateMeddiumRoom(ref x, ref y);
                            break;

                        case RoomType.Big:
                            generateBigRoom(ref x, ref y);
                            break;

                        case RoomType.Special:
                            generateSpecialRoom(ref x, ref y);
                            break;
                    }
                }
                else
                {
                    switch (this.frame[x, y].Type)
                    {
                        case RoomType.Small:
                            break;

                        case RoomType.Meddium:
                            x++;
                            break;

                        case RoomType.Big:
                            x += 2;
                            break;
                    }
                }
            }
        }
    }

    void generateSmallRoom(ref int x, ref int y)
    {
        this.rooms.Add(GameObject.Instantiate(this.SmallRoom[rnd.Next(0, this.SmallRoom.Length)]));
        this.rooms[this.frame[x, y].Index - 1].transform.parent = this.transform;
        this.rooms[this.frame[x, y].Index - 1].transform.SetPositionAndRotation(new Vector3(x * this.RoomSize.x, 0, y * this.RoomSize.x), Quaternion.Euler(0, 90 * this.rnd.Next(0, 4), 0));
        //this.rooms[this.frame[x, y].Index - 1].transform.localScale = new Vector3(this.RoomSize.x, this.RoomSize.y, this.RoomSize.x);
        //this.rooms[this.frame[x, y].Index - 1].GetComponent<Renderer>().material.color = new UnityEngine.Color(rnd.Next(255) / 255f, rnd.Next(255) / 255f, rnd.Next(255) / 255f);
        //this.rooms[this.frame[x, y].Index - 1].GetComponent<BoxCollider>().size = new Vector3(1f, 4, 1f);
        this.rooms[this.frame[x, y].Index - 1].GetComponent<TileController>()._setRoomType(RoomType.Small);
        this.rooms[this.frame[x, y].Index - 1].GetComponent<TileController>()._addRnd(this.rnd);
        this.frame[x, y].exist = true;
    }

    void generateMeddiumRoom(ref int x, ref int y)
    {
        this.rooms.Add(GameObject.Instantiate(this.MeddiumRoom[rnd.Next(0, this.MeddiumRoom.Length)]));
        this.rooms[this.frame[x, y].Index - 1].transform.parent = this.transform;
        this.rooms[this.frame[x, y].Index - 1].transform.SetPositionAndRotation(new Vector3((x + 0.5f) * this.RoomSize.x, 0, (y + 0.5f) * this.RoomSize.x), Quaternion.Euler(0, 90 * this.rnd.Next(0, 4), 0));
        //this.rooms[this.frame[x, y].Index - 1].transform.localScale = new Vector3(this.RoomSize.x * 2f, this.RoomSize.y, this.RoomSize.x * 2f);
        //this.rooms[this.frame[x, y].Index - 1].GetComponent<Renderer>().material.color = new UnityEngine.Color(rnd.Next(255) / 255f, rnd.Next(255) / 255f, rnd.Next(255) / 255f);
        //this.rooms[this.frame[x, y].Index - 1].GetComponent<BoxCollider>().size = new Vector3(1f, 4, 1f);
        this.rooms[this.frame[x, y].Index - 1].GetComponent<TileController>()._setRoomType(RoomType.Meddium);
        this.rooms[this.frame[x, y].Index - 1].GetComponent<TileController>()._addRnd(this.rnd);

        for (int i = 0; i < 2; i++, x++)
        {
            this.frame[x, y].exist = true;
            this.frame[x, y + 1].exist = true;
        }
        x--;
    }

    void generateBigRoom(ref int x, ref int y)
    {
        if (x == FrameSize.x - 3 || x == 0)
        {
            int buff = rnd.Next(0, this.BigRoom.Length);

            this.rooms.Add(GameObject.Instantiate(this.BigRoom[buff]));

            if (buff < 1)
            {
                if (x == FrameSize.x - 3)
                {
                    this.rooms[this.frame[x, y].Index - 1].transform.SetPositionAndRotation(new Vector3((x + 1) * this.RoomSize.x, 0, (y + 1) * this.RoomSize.x), Quaternion.Euler(0, 0, 0));
                }
                else
                {
                    this.rooms[this.frame[x, y].Index - 1].transform.SetPositionAndRotation(new Vector3((x + 1) * this.RoomSize.x, 0, (y + 1) * this.RoomSize.x), Quaternion.Euler(0, 180, 0));
                }
            }
            else
            {
                this.rooms[this.frame[x, y].Index - 1].transform.SetPositionAndRotation(new Vector3((x + 1) * this.RoomSize.x, 0, (y + 1) * this.RoomSize.x), Quaternion.Euler(0, 90 * this.rnd.Next(0, 4), 0));
            }
        }
        else
        {
            this.rooms.Add(GameObject.Instantiate(this.BigRoom[rnd.Next(1, this.BigRoom.Length)]));
            this.rooms[this.frame[x, y].Index - 1].transform.SetPositionAndRotation(new Vector3((x + 1) * this.RoomSize.x, 0, (y + 1) * this.RoomSize.x), Quaternion.Euler(0, 90 * this.rnd.Next(0, 4), 0));
        }

        this.rooms[this.frame[x, y].Index - 1].transform.parent = this.transform;
        //this.rooms[this.frame[x, y].Index - 1].transform.localScale = new Vector3(this.RoomSize.x * 2f, this.RoomSize.y, this.RoomSize.x * 2f);
        //this.rooms[this.frame[x, y].Index - 1].GetComponent<Renderer>().material.color = new UnityEngine.Color(rnd.Next(255) / 255f, rnd.Next(255) / 255f, rnd.Next(255) / 255f);
        //this.rooms[this.frame[x, y].Index - 1].GetComponent<BoxCollider>().size = new Vector3(1f, 4, 1f);
        this.rooms[this.frame[x, y].Index - 1].GetComponent<TileController>()._setRoomType(RoomType.Big);
        this.rooms[this.frame[x, y].Index - 1].GetComponent<TileController>()._addRnd(this.rnd);

        for (int i = 0; i < 3; i++, x++)
        {
            this.frame[x, y].exist = true;
            this.frame[x, y + 1].exist = true;
            this.frame[x, y + 2].exist = true;
        }
        x--;
    }

    void generateSpecialRoom(ref int x, ref int y)
    {
        switch (this.frame[x, y].Index)
        {
            case 1:
                this.rooms[0] = GameObject.Instantiate(this.StartRoom, new Vector3((x + 1.5f) * this.RoomSize.x, 0, (y + 1.5f) * this.RoomSize.x), Quaternion.identity);
                this.rooms[this.frame[x, y].Index - 1].transform.parent = this.transform;
                //this.rooms[this.frame[x, y].Index - 1].transform.localScale = new Vector3(this.RoomSize.x * 3f, this.RoomSize.y, this.RoomSize.x * 3f);
                //this.rooms[this.frame[x, y].Index - 1].GetComponent<Renderer>().material.color = new UnityEngine.Color(rnd.Next(255) / 255f, rnd.Next(255) / 255f, rnd.Next(255) / 255f);
                break;

            case 2:
                this.rooms[1] = GameObject.Instantiate(this.MiddleRoom, new Vector3((x + 1.5f) * this.RoomSize.x, 0, (y + 1.5f) * this.RoomSize.x), Quaternion.identity);
                this.rooms[this.frame[x, y].Index - 1].transform.parent = this.transform;
                //this.rooms[this.frame[x, y].Index - 1].transform.localScale = new Vector3(this.RoomSize.x * 3f, this.RoomSize.y, this.RoomSize.x * 3f);
                //this.rooms[this.frame[x, y].Index - 1].GetComponent<Renderer>().material.color = new UnityEngine.Color(rnd.Next(255) / 255f, rnd.Next(255) / 255f, rnd.Next(255) / 255f);
                break;

            case 3:
                this.rooms[2] = GameObject.Instantiate(this.EndRoom, new Vector3((x + 1.5f) * this.RoomSize.x, 0, (y + 1.5f) * this.RoomSize.x), Quaternion.identity);
                this.rooms[this.frame[x, y].Index - 1].transform.parent = this.transform;
                //this.rooms[this.frame[x, y].Index - 1].transform.localScale = new Vector3(this.RoomSize.x * 3f, this.RoomSize.y, this.RoomSize.x * 3f);
                //this.rooms[this.frame[x, y].Index - 1].GetComponent<Renderer>().material.color = new UnityEngine.Color(rnd.Next(255) / 255f, rnd.Next(255) / 255f, rnd.Next(255) / 255f);
                break;
        }
        //this.rooms[this.frame[x, y].Index - 1].GetComponent<BoxCollider>().size = new Vector3(1f, 4, 1f);
        this.rooms[this.frame[x, y].Index - 1].GetComponent<TileController>()._setRoomType(RoomType.Special);
        this.rooms[this.frame[x, y].Index - 1].GetComponent<TileController>()._addRnd(this.rnd);

        for (int i = 0; i < 4; i++, x++)
        {
            this.frame[x, y].exist = true;
            this.frame[x, y + 1].exist = true;
            this.frame[x, y + 2].exist = true;
            this.frame[x, y + 3].exist = true;
        }
        x--;
    }

    void generateDoor()
    {
        GameObject buffDoor;

        for (int y = 0; y < this.FrameSize.y; y++)
        {
            for (int x = 0; x < this.FrameSize.x; x++)
            {
                if (x + 1 < this.FrameSize.x && this.frame[x, y].Index != this.frame[x + 1, y].Index)
                {
                    buffDoor = GameObject.Instantiate(this.Door);
                    buffDoor.transform.parent = this.transform;
                    buffDoor.transform.SetPositionAndRotation(new Vector3((x + 0.5f) * this.RoomSize.x, this.Door.transform.localScale.y / 2, y * this.RoomSize.x), Quaternion.Euler(0, 90, 0));
                    this.rooms[this.frame[x, y].Index - 1].GetComponent<TileController>().AddDoor(buffDoor);
                    this.rooms[this.frame[x + 1, y].Index - 1].GetComponent<TileController>().AddDoor(buffDoor);
                }
                else
                {
                    if (y + 1 < this.FrameSize.y && this.frame[x, y].Index == this.frame[x, y + 1].Index)
                    {
                        switch (this.frame[x, y].Type)
                        {
                            case RoomType.Big:
                                x++;
                                break;

                            case RoomType.Special:
                                x += 2;
                                break;
                        }
                        continue;
                    }
                }

                if (y + 1 < this.FrameSize.y && this.frame[x, y].Index != this.frame[x, y + 1].Index)
                {
                    buffDoor = GameObject.Instantiate(this.Door);
                    buffDoor.transform.parent = this.transform;
                    buffDoor.transform.SetPositionAndRotation(new Vector3(x * this.RoomSize.x, this.Door.transform.localScale.y / 2, (y + 0.5f) * this.RoomSize.x), Quaternion.identity);
                    this.rooms[this.frame[x, y].Index - 1].GetComponent<TileController>().AddDoor(buffDoor);
                    this.rooms[this.frame[x, y + 1].Index - 1].GetComponent<TileController>().AddDoor(buffDoor);
                }
            }
        }
    }

    void generateBorderMAP()
    {
        float borderDivider = 10f;


        // down
        GameObject partOfBorder = GameObject.CreatePrimitive(PrimitiveType.Cube);
        partOfBorder.transform.parent = this.transform;
        partOfBorder.transform.localScale = new Vector3(this.RoomSize.x * (this.FrameSize.x + 2 / borderDivider),
                                                        10,
                                                        this.RoomSize.x / borderDivider);

        partOfBorder.transform.position = new Vector3(this.RoomSize.x * (this.FrameSize.x - 1) / 2f,
                                                      5,
                                                      -((this.RoomSize.x + this.RoomSize.x / borderDivider) / 2f));
        partOfBorder.AddComponent<Wall>();
        partOfBorder.GetComponent<Renderer>().material = wallMaterial;
        partOfBorder.name = "BorderWall";


        // up
        partOfBorder = GameObject.CreatePrimitive(PrimitiveType.Cube);
        partOfBorder.transform.parent = this.transform;
        partOfBorder.transform.localScale = new Vector3(this.RoomSize.x * (this.FrameSize.x + 2 / borderDivider),
                                                        10,
                                                        this.RoomSize.x / borderDivider);

        partOfBorder.transform.position = new Vector3(this.RoomSize.x * (this.FrameSize.x - 1) / 2f,
                                                      5,
                                                      this.RoomSize.x * this.FrameSize.y + (this.RoomSize.x / borderDivider - this.RoomSize.x) / 2f);
        partOfBorder.AddComponent<Wall>();
        partOfBorder.GetComponent<Renderer>().material = wallMaterial;
        partOfBorder.name = "BorderWall";


        // left
        partOfBorder = GameObject.CreatePrimitive(PrimitiveType.Cube);
        partOfBorder.transform.parent = this.transform;
        partOfBorder.transform.localScale = new Vector3(this.RoomSize.x / borderDivider,
                                                        10,
                                                        this.RoomSize.x * this.FrameSize.y);

        partOfBorder.transform.position = new Vector3(-((this.RoomSize.x + this.RoomSize.x / borderDivider) / 2f),
                                                      5,
                                                      this.RoomSize.x * (this.FrameSize.y - 1) / 2f);
        partOfBorder.AddComponent<Wall>();
        partOfBorder.GetComponent<Renderer>().material = wallMaterial;
        partOfBorder.name = "BorderWall";


        // right
        partOfBorder = GameObject.CreatePrimitive(PrimitiveType.Cube);
        partOfBorder.transform.parent = this.transform;
        partOfBorder.transform.localScale = new Vector3(this.RoomSize.x / borderDivider,
                                                        10,
                                                        this.RoomSize.x * this.FrameSize.y);
        partOfBorder.transform.position = new Vector3(this.RoomSize.x * this.FrameSize.x + (this.RoomSize.x / borderDivider - this.RoomSize.x) / 2f,
                                                      5,
                                                      this.RoomSize.x * (this.FrameSize.y - 1) / 2f);
        partOfBorder.name = "BorderWall";
        partOfBorder.AddComponent<Wall>();
        partOfBorder.GetComponent<Renderer>().material = wallMaterial;
    }

    private void generateGruz()
    {
        GameObject buff;

        for (int y = Convert.ToInt32(this.FrameSize.y / 2f); y < this.FrameSize.y; y++)
        {
            for (int x = 0; x < this.FrameSize.x; x++)
            {
                if (frame[x, y].Type != RoomType.Special)
                {
                    buff = GameObject.Instantiate(this.gruz);
                    gruz.transform.position = new Vector3(this.rooms[this.frame[x, y].Index - 1].transform.position.x, 5f, this.rooms[this.frame[x, y].Index - 1].transform.position.z);
                    gruz.transform.localScale = new Vector3(this.rooms[this.frame[x, y].Index - 1].transform.localScale.x - 2f, 7.5f, this.rooms[this.frame[x, y].Index - 1].transform.localScale.z - 2f);

                }
            }
        }
    }

    private void enemiesSpawn()
    {
        foreach (GameObject room in this.rooms)
        {
            var buff = room.GetComponent<TileController>();

            switch (buff.MyType)
            {
                case RoomType.Small:
                    buff.MaxEnemy = this.MaxEnemiesSmallRoom;
                    break;
                case RoomType.Meddium:
                    buff.MaxEnemy = this.MaxEnemiesSmallRoom;
                    break;
                case RoomType.Big:
                    buff.MaxEnemy = this.MaxEnemiesSmallRoom;
                    break;
                case RoomType.Special:
                    continue;
                    //break;
            }
            buff.SpawnEnemies(this.rnd.Next(2) != 0 ? true : false);
        }
    }
}

// Tool
//##########################

// Debug.LogError($"{this.frame[x, y].Index}    ----     ${this.rooms.Count()}");

//##########################
/*
 string buff ="";
        for (int i = 0; i < this.FrameSize.y; i++)
        {
            for (int j = 0; j < this.FrameSize.x; j++)
            {
                buff += $"{this.frame[j, i].Index}     ";
            }
            Debug.Log(buff);
            buff = "";
        }
 */
//##########################