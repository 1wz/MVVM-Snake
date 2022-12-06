using System.Collections.Generic;

namespace MVVM.Model
{

    public class Snake
    {
        private Queue<(int,int)> snake = new Queue<(int, int)>();
        private (int, int) head = (0, 0);
        public int length { get { return snake.Count; } }

        public (int,int) Move(Direction direction)
        {
            (int,int) step = direction switch
            {
                Direction.Up => (0,1),
                Direction.Down => (0,-1),
                Direction.Right => (1,0),
                Direction.Left=>(-1,0)
            };

            head = (head.Item1 + step.Item1, head.Item2 + step.Item2);
            snake.Enqueue(head);
            return head;

        }

        public (int,int) CutOffTheTail()
        {
            return snake.Dequeue();
        }

        public bool Contains((int, int) point)
        {
            return snake.Contains(point);
        }
    }
}