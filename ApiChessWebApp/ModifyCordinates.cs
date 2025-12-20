namespace ApiChessWebApp
{
    public enum AddSubstractFlag
    {
        XYBoth,
        XOnly,
        YOnly,
        None
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

        public static Cordinates SubstractInXAddInYCordinates(Cordinates c, int n, AddSubstractFlag flag = AddSubstractFlag.None)
        {
            var x = c.X;
            var y = c.Y;
            x = x - n;
            y = y + n;
            return new Cordinates(x, y);
        }

        public static Cordinates AddInXSubstractInYCordinates(Cordinates c, int n, AddSubstractFlag flag = AddSubstractFlag.None)
        {
            var x = c.X;
            var y = c.Y;
            x = x + n;
            y = y - n;
            return new Cordinates(x, y);
        }
    }
}
