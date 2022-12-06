//using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace MVVM.View
{

    class Field
    {
        Material[,] points;
        public Field(int waight,int hight)
        {
            points = new Material[waight, hight];

            float maxY = (float)hight / 2 + 0.5f;
            float maxX = (float)waight / 2 + 0.5f;
            for(float y=-(float)hight / 2 + 0.5f;y<maxY;y++)
            {
                for (float x = -(float)hight / 2 + 0.5f; y < maxX; x++)
                {
                    GameObject point = GameObject.CreatePrimitive(PrimitiveType.Cube);
                    point.transform.Translate(new Vector3(x, y));
                    point.GetComponent<Renderer>().material;
                }
            }
            GameObject.CreatePrimitive(PrimitiveType.Cube).transform.position = new Vector2(-1, 0);
            GameObject.CreatePrimitive(PrimitiveType.Cube).GetComponent<Renderer>().material.color = Color.yellow;
        }
    }
}
