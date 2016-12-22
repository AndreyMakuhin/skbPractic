namespace Mazes
{
	public static class PyramidMazeTask
	{
		public static void MoveOut(Robot robot, int width, int height)
		{
            var dir = Direction.Right;
            var startWidth = width - 3;
            for (int i = 0; i < ((height - 2) / 2) + 1; i++)
            {
                MoveHorizontal(robot, startWidth, dir);
                if (i != ((height - 2) / 2))
                    MoveVertical(robot, 2, Direction.Up);

                if (dir == Direction.Right)
                    dir = Direction.Left;
                else dir = Direction.Right;
                startWidth -= 2;
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