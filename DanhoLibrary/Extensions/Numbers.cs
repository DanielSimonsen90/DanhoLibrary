using static DanhoLibrary.Extensions.DanhoExtender;

namespace DanhoLibrary.Extensions
{
    public static class Numbers
    {
        public delegate T IForCallback<T>(int i);

        public static T For<T>(this int length, IForCallback<T> callback)
        {
            T result = default;
         
            for (int i = 0; i < length; i++)
            {
                result = callback(i);

                if (result != null) break;
            }

            return result;
        }
        public static R Reduce<R>(this int length, ReduceCallback<R, int> callback, R defaultValue)
        {
            int[] source = new int[length];
            for (int i = 0; i < length; i++) source[i] = i;

            return source.Reduce((result, i) => callback(result, i), defaultValue);
        }
    }
}
