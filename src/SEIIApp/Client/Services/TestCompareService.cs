using SEIIApp.Shared;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace SEIIApp.Client.Services
{
    public class TestCompareService : IEqualityComparer<TestBaseDTO>
    {
        public bool Equals(TestBaseDTO x, TestBaseDTO y)
        {
            if (x == null && y == null)
                return true;
            else if (x == null || y == null)
                return false;
            else if (x.TestID == y.TestID && x.Topic.Equals(y.Topic))
                return true;
            else
                return false;    
        }

        public int GetHashCode([DisallowNull] TestBaseDTO obj)
        {
            return (obj.TestID.GetHashCode() + obj.Topic.GetHashCode()).GetHashCode();
        }
    }
}
