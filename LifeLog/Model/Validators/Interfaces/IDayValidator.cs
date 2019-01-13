using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LifeLog.Model
{
    public interface IDayValidator
    {
        bool Validate(DateTime date, int score);
    }
}
