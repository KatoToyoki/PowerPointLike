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
        public PresentationModel(ModelAlias.Model model)
        {
            _model = model;
        }

        public void AddItem(string shape)
        {
            _model.AddItem(shape);
        }

        public string[] GetCurrentElement()
        {
            return _model.GetCurrentElement();
        }

        public void DeleteCertainElement(int dataIndex, int deleteIndex)
        {
            if (dataIndex == DATA_DELETE_INDEX)
            {
                _model.DeleteCertainElement(deleteIndex);
            }
        }

        public int GetDeleteIndex(int dataIndex, int deleteIndex)
        {
            if (dataIndex == DATA_DELETE_INDEX)
            {
                return deleteIndex;

            }
            return INVAILD;
        }
    }
}
