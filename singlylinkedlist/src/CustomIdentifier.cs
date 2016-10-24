using System;

namespace SinglyLinkedList
{
    public static class CustomIdentifier
    {
        private static long lastUID = 0;

        public static long GetUID()
        {
            return lastUID++;
        }
    }
}