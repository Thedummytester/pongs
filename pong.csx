using System;
using System.Threading;

class Pong
{
    static int width = 40;
    static int height = 20;
    static int ballX = width / 2;
    static int ballY = height / 2;
    static int dx = 1;
    static int dy = 1;
    static int leftPaddleY = height / 2 - 2;
    static int rightPaddleY = height / 2 - 2;
    static int paddleSize = 4;

    static void Draw()
    {
        Console.Clear();
        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                if (x == 0 && y >= leftPaddleY && y < leftPaddleY + paddleSize)
                    Console.Write("|");
                else if (x == width - 1 && y >= rightPaddleY && y < rightPaddleY + paddleSize)
                    Console.Write("|");
                else if (x == ballX && y == ballY)
                    Console.Write("O");
                else
                    Console.Write(" ");
            }
            Console.WriteLine();
        }
    }

    static void Update()
    {
        ballX += dx;
        ballY += dy;

        // Bounce top/bottom
        if (ballY <= 0 || ballY >= height - 1)
            dy = -dy;

        // Bounce paddles
        if (ballX == 1 && ballY >= leftPaddleY && ballY < leftPaddleY + paddleSize)
            dx = -dx;
        if (ballX == width - 2 && ballY >= rightPaddleY && ballY < rightPaddleY + paddleSize)
            dx = -dx;

        // Reset if scored
        if (ballX <= 0 || ballX >= width - 1)
        {
            ballX = width / 2;
            ballY = height / 2;
        }
    }

    static void Main()
    {
        Console.CursorVisible = false;
        while (true)
        {
            Draw();

            // Move paddles with keys
            if (Console.KeyAvailable)
            {
                var key = Console.ReadKey(true).Key;
                if (key == ConsoleKey.W && leftPaddleY > 0) leftPaddleY--;
                if (key == ConsoleKey.S && leftPaddleY + paddleSize < height) leftPaddleY++;
                if (key == ConsoleKey.UpArrow && rightPaddleY > 0) rightPaddleY--;
                if (key == ConsoleKey.DownArrow && rightPaddleY + paddleSize < height) rightPaddleY++;
            }

            Update();
            Thread.Sleep(100);
        }
    }
}
