using System;
using System.Collections.Generic;
using System.Text;

namespace NiTiS.Core.Data;

public interface IHaveOpenConstructor<T>
{
    public Func<T> GetConstructor();
}