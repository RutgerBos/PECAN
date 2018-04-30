using System;

namespace PECAN.Parameters
{
    public class Parameter<T> : ValueContainingClass<T>
    {
        public Parameter(string paramName)
            : base( Parameter<T>.GetValue(paramName))
        {
        }

        /// <summary>
        /// TODO: Get value from config file.
        /// As much as I hate it, I think the easiest and cleanest way is going to be a configuration class with a singleton.
        /// </summary>
        /// <param name="paramName"></param>
        /// <returns></returns>
        private static T GetValue(string paramName)
        {
            throw new NotImplementedException();
        }
    }
}