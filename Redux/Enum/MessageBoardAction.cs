using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Redux.Enum
{
    public enum MessageBoardAction : byte
    {
        None = 0,
        Del = 1,
        GetList = 2,
        List = 3,
        GetWords = 4,
    }
}
