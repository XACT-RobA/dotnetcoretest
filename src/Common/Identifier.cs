using System;

namespace DotNetCoreTest.Common
{
    public static class Identifier
    {
        private static long lastUID = 0;

        public static long GetUID()
        {
            return lastUID++;
        }
    }
}
