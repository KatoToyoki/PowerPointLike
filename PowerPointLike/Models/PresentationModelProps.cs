using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerPointLike
{
    public partial class PresentationModel
    {
        public const int DATA_DELETE_INDEX = 0;
        public const int INVALID = -1;
        private Model _model;

        public bool _isLineButtonCheck
        {
            get; set;
        }
        public bool _isRectangleButtonCheck
        {
            get; set;
        }
        public bool _isCircleButtonCheck
        {
            get; set;
        }

    }
}
