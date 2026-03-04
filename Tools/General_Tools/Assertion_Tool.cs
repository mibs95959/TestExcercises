using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tools.General_Tools
{
    /// <summary>
    /// The initial idea of this class is to help us save lines of code when asserting at the level of the Steps.
    /// No only save us lines but also to increase the possibilities of what we can assert.
    /// 
    /// It might be dumb, but it can save us lines of code just by simply encapsulating.
    /// 
    /// "A simple spell, but quite effective"
    /// 
    /// @TODO: Expand this class, it has some potential to be used in many places!
    /// </summary>
    public class Assertion_Tool
    {

        /// <summary>
        /// Also works for plural, if needed modify this method to adopt more wordings or simply create another one.
        /// </summary>
        /// <param name="condition"></param>
        /// <param name="isOrIsnt"></param>
        /// <returns></returns>
        public static bool IsOrIsnt(bool condition, string isOrIsnt)
        {
            if (isOrIsnt.Equals("is") || isOrIsnt.Equals("are"))
            {
                return condition.Equals(true);
            }
            else
            {
                return condition.Equals(false);
            }
        }

        /// <summary>
        /// Checks if value2 is within a specified percentage range of value1.
        /// </summary>
        /// <param name="value1">The base value.</param>
        /// <param name="value2">The value to check.</param>
        /// <param name="percent">The acceptable percentage range.</param>
        /// <returns>True if value2 is within the plus-minus percentage range of value1, otherwise false.</returns>
        public static bool IsValueWithinPercentage(double value1, double value2, double percent)
        {
            double tolerance = value1 * (percent / 100.0);
            double lowerBound = value1 - tolerance;
            double upperBound = value1 + tolerance;

            return (value2 >= lowerBound && value2 <= upperBound);
        }

    }
}
