using System;
using System.Collections.Generic;
using System.Text;

namespace NiTiS.Core.Data
{
    public interface IData
    {
        public void Write(IDataStorage storage);
    }
}
