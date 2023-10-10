using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerPointLike.Shape
{

    public partial class Shape
    {
        public Shape()
        {
            SetInitCoordinate();
        }

        public void SetInitCoordinate()
        {
            var rand = new Random();
            for (int i = 0; i < 2; i++)
            {
                _shapeCoordinate[i]._x = rand.Next(100);
                _shapeCoordinate[i]._y = rand.Next(100);
            }

        }
    }

}
