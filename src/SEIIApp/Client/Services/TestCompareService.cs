using SEIIApp.Shared;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace SEIIApp.Client.Services
{
    public class TestCompareService : IEqualityComparer<TestBaseDTO>
    {
        /// <summary>
        /// Compares two tests by their id and topic.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Returns the hash code of a test calculated with the id and the topic.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public int GetHashCode([DisallowNull] TestBaseDTO obj)
        {
            return (obj.TestID.GetHashCode() + obj.Topic.GetHashCode()).GetHashCode();
        }
    }
}
