

namespace Intarface
{
    class BMVSeven : ICar
    {
        public void Create()
        {
            throw new System.NotImplementedException();
        }

        public int Move(int distance)
        {
            return distance / 100;
        }
    }
}
