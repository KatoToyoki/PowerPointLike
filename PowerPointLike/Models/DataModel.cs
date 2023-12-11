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

        private Model _model;

        public DataModel(Model model)
        {
            _model = model;
        }

        /// <summary>
        /// Method <c>AddItem</c>
        /// add the assigned shape to the shape container
        /// </summary>
        /// <param name="shape">the assigned shape</param>
        public void AddItem(string shape, int dataIndex, int deleteIndex)
        {
            if (shape == string.Empty)
            {
                return;
            }
            _model.AddItem(shape, dataIndex, deleteIndex);
        }

        /// <summary>
        /// Method <c>DeleteCertainElement</c>
        /// delete the assigned element
        /// </summary>
        /// <param name="dataIndex">to determine if this function will be executed</param>
        /// <param name="deleteIndex">the index of the shape in the container</param>
        public void DeleteCertainElement(string shapeName, int dataIndex, int deleteIndex)
        {
            _model.DeleteCertainElement(shapeName, dataIndex, deleteIndex);
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

        /// <summary>
        /// Method <c>GetContainerLength</c>
        /// to get the shapes container's length
        /// </summary>
        /// <returns>the length of shapes container</returns>
        public int GetContainerLength()
        {
            return _model.GetContainerLength();
        }

        /// <summary>
        /// Method <c>GetOneElement</c>
        /// get the delete button, name, and its coordinate in one time
        /// the informatiob is constructed by a string array
        /// </summary>
        /// <param name="index"></param>
        /// <returns>one element info separated in string array</returns>
        public string[] GetOneElement(int index)
        {
            return _model.GetOneElement(index);
        }

        /// <summary>
        /// Method <c>DeleteSelectOne</c>
        /// </summary>
        /// <param name="index"></param>
        public void DeleteSelectOne()
        {
            _model.DeleteSelectOne();
        }

        /// <summary>
        /// Method <c>GetAllContainerData</c>
        /// </summary>
        /// <returns></returns>
        public List<string[]> GetAllContainerData()
        {
            List<string[]> tableData = new List<string[]>();

            for (int i = 0; i < GetContainerLength(); i++)
            {
                string[] element = GetOneElement(i);
                tableData.Add(new string[] { element[(int)DataModel.Data.DataDeleteIndex], element[(int)DataModel.Data.DataNameIndex], element[(int)DataModel.Data.DataCoordinateIndex] });
            }

            return tableData;
        }

        /// <summary>
        /// Method <c>ChangeCanvasSize</c>
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        public void ChangeCanvasSize(int width, int height)
        {
            _model.ChangeCanvasSize(width, height);
        }
    }
}
