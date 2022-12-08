
using UnityEngine;

namespace MVVM.View
{

    class Field
    {
        Renderer[,] points;
        readonly Color DefoltColor=Color.black;
        private int _height;
        private int _width;
        public Field(int width,int height)
        {
            points = new Renderer[width, height];
            _height = height;
            _width = width;

            float YPosition = -(float)height / 2 + 0.5f;
            float beginningXPosition = -(float)width / 2 + 0.5f;
            for(int y=0;y<height;y++)
            {
                float XPosition = beginningXPosition;
                for (int x = 0; x < width; x++)
                {
                    var point = GameObject.CreatePrimitive(PrimitiveType.Cube);
                    point.transform.Translate(new Vector3(XPosition, YPosition));
                    var renderer=point.GetComponent<Renderer>();
                    renderer.material.color = DefoltColor;
                    points[x, y] = renderer;
                    XPosition++;
                }
                YPosition++;
            }
        }

        public bool TrySetPoint(int x, int y,Color color)
        {
            if (!Contains(x, y)) return false;
            points[x, y].material.color = color;
            return true;
        }
        public bool TrySetPoint((int,int) point,Color color)
        {
            return TrySetPoint(point.Item1, point.Item2, color);
        }
        public  bool TryResetPoint(int x, int y)
        {
            if (!Contains(x, y)) return false;
            points[x, y].material.color = DefoltColor;
            return true;
        }
        public bool TryResetPoint((int,int) point)
        {
            return TryResetPoint(point.Item1, point.Item2);
        }
        private bool Contains(float x, float y)
        {
            return x < _width && x >= 0 && y < _height && y >= 0;
        }

    }
}
