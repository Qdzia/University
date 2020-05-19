using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniTC.Controls
{
    public interface IPanelTC
    {
        string Path { get; set; }
        List<string> Drives { get; set; }
        List<string> Files { get; set; }

    }
}
