using UnityEngine;

public class Wall : MonoBehaviour
{
    public bool lookedAtWall = false;
    public bool lowering = false;
    bool oneTimeUse = true;
    float height;
    float heightProcentage;
    float heightMax;
    float percantage = 0.1f;
    public Renderer mat;
    Color col;
    private void Start()
    {
        if (this.transform.tag == "Wall" || this.transform.name == "BorderWall")
        {
            mat = GetComponent<Renderer>();
        }
/*        if (this.transform.name == "BorderWall")
        {
            mat.material.renderQueue = 3002;
        }
        else
        {
            mat.material.renderQueue = 3001;
        }*/
        col = mat.material.color;
        col.a = 1;
        mat.material.color = col;
    }
    void Update()
    {
        LowerWall();
    }

    void LowerWall()
    {
        if (lookedAtWall == true)
        {
            if (oneTimeUse == true)
            {
                heightMax = transform.position.y;
                oneTimeUse = false;
            }
            if (lowering == true)
            {
                //height = transform.position.y;
                //heightProcentage = heightMax * percantage;
                if (col.a >= 0.1f)
                {
                    col.a -= 0.01f;
                    mat.material.color = col;
                }
                else
                {
                    lowering = false;
                }
                /*                if (height > heightProcentage)//-3
                                {
                                    height -= percantage;
                                    transform.position = new Vector3(transform.position.x, height, transform.position.z);

                                }
                                else
                                {
                                    lowering = false;
                                }*/
            }
            else
            {
                float dst = Vector3.Distance(transform.position, GameObject.Find("Astronaut").transform.position);

                if (dst > 15f)
                {
                    if (col.a <= 1f)
                    {
                        col.a += 0.01f;
                        mat.material.color = col;
                    }
                    else
                    {
                        lookedAtWall = false;
                    }
                    /*                    if (height <= heightMax)
                                        {
                                            height += 0.1f;
                                            transform.position = new Vector3(transform.position.x, height, transform.position.z);
                                        }
                                        else
                                        {
                                            transform.position = new Vector3(transform.position.x, heightMax, transform.position.z);
                                            lookedAtWall = false;
                                        }*/
                }
            }
        }
    }
}
