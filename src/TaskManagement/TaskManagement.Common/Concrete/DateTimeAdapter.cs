using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Common.Interface;

namespace TaskManagement.Common.Concrete
{
    public class DateTimeAdapter: IDateTime
    {
        public DateTime UtcNow { get { return DateTime.UtcNow; } }

    }
}
