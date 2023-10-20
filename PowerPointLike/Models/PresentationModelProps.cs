using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelAlias = PowerPointLike.Model;

namespace PowerPointLike.PresentationModel
{
    public partial class PresentationModel
    {
        public const int DATA_DELETE_INDEX = 0;
        public const int BUTTON_QUANTITY = 3;
        public const int INVALID = -1;
        private ModelAlias.Model _model;

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
