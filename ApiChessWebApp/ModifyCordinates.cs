namespace ApiChessWebApp
{
    public enum AddSubstractFlag
    {
        XYBoth,
        XOnly,
        YOnly
    }
    public static class ModifyCordinates
    {

        public static Cordinates AddVariableInCordinates(Cordinates c, int n, AddSubstractFlag flag)
        {
            var x = c.X;
            var y = c.Y;
            if (flag == AddSubstractFlag.XOnly)
            { 
                return new Cordinates(x+n, y);
            }
            else if(flag == AddSubstractFlag.YOnly)
            {
                return new Cordinates(x, y+n);
            }
            else if (flag == AddSubstractFlag.XYBoth)
            {
                return new Cordinates(x+n, y+n);
            }
            return new Cordinates(x, y);
        }

        public static Cordinates SubstractVariableInCordinates(Cordinates c, int n, AddSubstractFlag flag)
        {
            var x = c.X;
            var y = c.Y;
            if (flag == AddSubstractFlag.XOnly)
            {
                return new Cordinates(x - n, y);
            }
            else if (flag == AddSubstractFlag.YOnly)
            {
                return new Cordinates(x, y - n);
            }
            else if (flag == AddSubstractFlag.XYBoth)
            {
                return new Cordinates(x - n, y - n);
            }
            return new Cordinates(x, y);
        }
    }
}
