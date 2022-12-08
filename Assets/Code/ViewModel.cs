
using UnityEngine;
using MVVM;
using MVVM.Model;
using MVVM.View;
public class ViewModel
{
    const int heightOfField = 9;
    const int widthOfField = 16;
    readonly Color colorDrow = Color.white;
    const float deltaTime = 0.2f;
    private Snake snake;
    private Field field;
    private Direction direction;
    private EventSender eventSender;
    private int length;
    private SimpleTimer timer;
    private (int, int) apple;

    public ViewModel()
    {
        eventSender = new EventSender();
        snake = new Snake();
        field = new Field(widthOfField, heightOfField);
        direction=Direction.Right;
        length = 3;
        timer = new SimpleTimer(Frame);
        InputObserver.InputEvent += Turn;
        MakeApple();
        Frame();
    }

    private void Frame()
    {
        (int, int) head = snake.GetNextPoint(direction);

        if (!field.TrySetPoint(head, colorDrow) || snake.Contains(head))
        {
            Debug.Log("Game Over");
            return;
        }
        snake.Move(direction);

        if(head ==apple)
        { 
            length++;
            MakeApple();
        }

        if (snake.length > length)
            field.TryResetPoint(snake.CutOffTheTail());

        timer.Set(deltaTime);
    }

    private void Turn(KeyCode keyCode)
    {
        if (direction==Direction.Up||direction==Direction.Down)
        {
            switch (keyCode)
            {
                case KeyCode.D: direction = Direction.Right;
                    break;
                case KeyCode.A: direction = Direction.Left;
                    break;
                        
            }
        }
        else
        {
            switch (keyCode)
            {
                case KeyCode.W:
                    direction = Direction.Up;
                    break;
                case KeyCode.S:
                    direction = Direction.Down;
                    break;

            }
        }
    }

    private void MakeApple()
    {
        int x;
        int y;
        do
        {
            x=Random.Range(0, widthOfField);
            y = Random.Range(0, heightOfField);
        }
        while (snake.Contains((x, y)));
        apple = (x, y);
        field.TrySetPoint(x, y, colorDrow);

    }
}
