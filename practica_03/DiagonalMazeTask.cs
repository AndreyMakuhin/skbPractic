namespace Mazes
{
	public static class DiagonalMazeTask
	{
        public static void MoveOut(Robot robot, int width, int height)
        {
            if (width > height)
            {
                for (int i = 0; i < height - 2; i++)
                {
                    MoveHorizontal(robot, width / (height - 1), Direction.Right);
                    if (i != (height - 2 - 1))
                        MoveVertical(robot, 1, Direction.Down);
                }
            }
            else
            {
                for (int i = 0; i < width - 2; i++)
                {
                    MoveVertical(robot, (height-3) / (width-2), Direction.Down);
                    if (i != (width - 3))
                        MoveHorizontal(robot, 1, Direction.Right);
                }
            }
        }
            

        

        public static void MoveVertical(Robot robot, int height, Direction dir)
        {
            for (int i = 0; i < height; i++)
            {
                robot.MoveTo(dir);
            }
        }

        public static void MoveHorizontal(Robot robot, int width, Direction dir)
        {
            for (int j = 0; j < width; j++)
            {
                robot.MoveTo(dir);
            }
        }


    }
}