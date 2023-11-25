using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerPointLike
{
    public class DataModel
    {
        public enum Data
        {
            DataDeleteIndex,
            DataNameIndex,
            DataCoordinateIndex
        }

        public const int DATA_DELETE_INDEX = 0;

        public DataModel(Model model)
        {
            _model = model;
        }
        /// <summary>
        /// Method <c>GetDeleteIndex</c>
        /// to get at which position should the shape be deleted
        /// </summary>
        /// <param name="dataIndex">to determine if this function will be executed</param>
        /// <param name="deleteIndex">the index of the shape in the container</param>
        /// <returns>the index</returns>
        public int? GetDeleteIndex(int dataIndex, int deleteIndex)
        {
            if (dataIndex == DATA_DELETE_INDEX)
            {
                return deleteIndex;
            }
            return null;
        }
    }
}
