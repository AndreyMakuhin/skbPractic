namespace Mazes
{
    public static class EmptyMazeTask
    {
        public static void MoveOut(Robot robot, int width, int height)
        {
            MoveVertical(robot, height);
            MoveHorizontal(robot, width);
        }

        public static void MoveVertical(Robot robot, int height)
        {
            for (int i = 0; i < height - 3; i++)
            {
                robot.MoveTo(Direction.Down);
            }
        }

        public static void MoveHorizontal(Robot robot, int width)
        {
            for (int j = 0; j < width - 3; j++)
            {
                robot.MoveTo(Direction.Right);
            }
        }
    }
}