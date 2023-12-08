using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerPointLike
{
    public interface ICommand
    {
        /// <summary>
        /// Method <c>Execute</c>
        /// </summary>
        void Execute();

        /// <summary>
        /// Method <c>ExecuteCancel</c>
        /// </summary>
        void ExecuteCancel();
    }
}
