using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTest.Templates.SupportUnitTest
{
    public class CallStatic : ICallStatic
    {
        private readonly ICallStatic _callStatic;
        public CallStatic(ICallStatic callStatic)
        {
            _callStatic = callStatic;
        }
        public int Add(int x, int y)
        {
            return _callStatic.Add(x, y);
        }
    }
}
