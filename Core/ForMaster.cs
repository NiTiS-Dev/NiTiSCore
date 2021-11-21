using NiTiS.Core.Variables;
using System;
using System.Threading.Tasks;

namespace NiTiS.Additions
{
    public static class ForMaster
    {
        public static async void Create1DGridAsync(int sizeX, bool startFromZero, Action<Vector1DInt> op) => await Task.Run( () => Create1DGrid(sizeX,startFromZero,op));
        public static async void Create2DGridAsync(int sizeX, int sizeZ, bool startFromZero, Action<Vector2DInt> op) => await Task.Run(() => Create2DGrid(sizeX, sizeZ, startFromZero, op));
        public static void Create1DGrid(int sizeX, bool startFromZero, Action<Vector1DInt> op)
        {
            if (startFromZero)
            {
                for (int x = 0; x < sizeX; x++)
                {
                    op(new Vector1DInt(x));
                }
            }
            else
            {
                for (int x = 1; x <= sizeX; x++)
                {
                    op(new Vector1DInt(x));
                }
            }
        }
        public static void Create2DGrid(int sizeX, int sizeZ, bool startFromZero, Action<Vector2DInt> op)
        {
            if (startFromZero)
            {
                for (int x = 0; x < sizeX; x++)
                {
                    for (int z = 0; z < sizeZ; z++)
                    {
                        op(new Vector2DInt(x,z));
                    }
                }
            }
            else
            {
                for (int x = 1; x <= sizeX; x++)
                {
                    for (int z = 1; z <= sizeZ; z++)
                    {
                        op(new Vector2DInt(x, z));
                    }
                }
            }
        }
    }
}
