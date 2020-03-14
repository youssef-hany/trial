using System;
using System.Runtime.InteropServices;

namespace Redux
{
    public unsafe class MSVCRT
    {
        private const string MSVCRT_DLL = @"C:\Windows\system32\msvcrt.dll";
        private const string MSVCRT_DLL_alt = @"D:\Windows\system32\msvcrt.dll";

        #region memcpy

        [DllImport(MSVCRT_DLL, EntryPoint = "memcpy", CallingConvention = CallingConvention.Cdecl)]
        private static extern void* _memcpy(void* dst, void* src, int length);

        [DllImport(MSVCRT_DLL_alt, EntryPoint = "memcpy", CallingConvention = CallingConvention.Cdecl)]
        private static extern void* _memcpy_alt(void* dst, void* src, int length);

        public static void* memcpy(void* dst, void* src, int length)
        {
            if (Environment.SystemDirectory.StartsWith("D"))
                return _memcpy_alt(dst, src, length);
            return _memcpy(dst, src, length);
        }

        #endregion

        #region memmove

        [DllImport(MSVCRT_DLL, CallingConvention = CallingConvention.Cdecl)]
        private static extern void* _memmove(void* dst, void* src, int length);

        [DllImport(MSVCRT_DLL_alt, CallingConvention = CallingConvention.Cdecl)]
        private static extern void* _memmove_alt(void* dst, void* src, int length);

        public static void* memmove(void* dst, void* src, int length)
        {
            if (Environment.SystemDirectory.StartsWith("D"))
                return _memmove_alt(dst, src, length);
            return _memmove(dst, src, length);
        }

        #endregion

        #region memset

        [DllImport(MSVCRT_DLL, EntryPoint = "memset", CallingConvention = CallingConvention.Cdecl)]
        private static extern void* _memset(void* dst, byte fill, int length);

        [DllImport(MSVCRT_DLL_alt, EntryPoint = "memset", CallingConvention = CallingConvention.Cdecl)]
        private static extern void* _memset_alt(void* dst, byte fill, int length);

        public static void* memset(void* dst, byte fill, int length)
        {
            if (Environment.SystemDirectory.StartsWith("D"))
                return _memset_alt(dst, fill, length);
            return _memset(dst, fill, length);
        }

        #endregion

        #region malloc

        [DllImport(MSVCRT_DLL, EntryPoint = "malloc", CallingConvention = CallingConvention.Cdecl)]
        private static extern void* _malloc(int size);

        [DllImport(MSVCRT_DLL_alt, EntryPoint = "malloc", CallingConvention = CallingConvention.Cdecl)]
        private static extern void* _malloc_alt(int size);

        public static void* malloc(int size)
        {
            if (Environment.SystemDirectory.StartsWith("D"))
                return _malloc_alt(size);
            return _malloc(size);
        }

        #endregion

        #region free

        [DllImport(MSVCRT_DLL, EntryPoint = "free", CallingConvention = CallingConvention.Cdecl)]
        private static extern void _free(void* memblock);

        [DllImport(MSVCRT_DLL_alt, EntryPoint = "free", CallingConvention = CallingConvention.Cdecl)]
        private static extern void _free_alt(void* memblock);

        public static void free(void* memblock)
        {
            if (Environment.SystemDirectory.StartsWith("D"))
                _free_alt(memblock);
            free(memblock);
        }

        #endregion

        #region realloc

        [DllImport(MSVCRT_DLL, EntryPoint = "realloc", CallingConvention = CallingConvention.Cdecl)]
        private static extern void* _realloc(void* memblock, int size);

        [DllImport(MSVCRT_DLL_alt, EntryPoint = "realloc", CallingConvention = CallingConvention.Cdecl)]
        private static extern void* _realloc_alt(void* memblock, int size);

        public static void* realloc(void* memblock, int size)
        {
            if (Environment.SystemDirectory.StartsWith("D"))
                _realloc_alt(memblock, size);
            return _realloc(memblock, size);
        }

        #endregion

        #region memcmp

        [DllImport(MSVCRT_DLL, EntryPoint = "memcmp", CallingConvention = CallingConvention.Cdecl)]
        private static extern int _memcmp(void* buf1, void* buf2, int count);

        [DllImport(MSVCRT_DLL_alt, EntryPoint = "memcmp", CallingConvention = CallingConvention.Cdecl)]
        private static extern int _memcmp_alt(void* buf1, void* buf2, int count);

        public static int memcmp(void* buf1, void* buf2, int count)
        {
            if (Environment.SystemDirectory.StartsWith("D"))
                return _memcmp_alt(buf1, buf2, count);
            return _memcmp(buf1, buf2, count);
        }

        #endregion
    }

    public static unsafe class NativeExtensions
    {
        public static void CopyTo(this string str, void* pDest)
        {
            var dest = (byte*) pDest;
            for (var i = 0; i < str.Length; i++)
            {
                dest[i] = (byte) str[i];
            }
        }

        public static byte[] UnsafeClone(this byte[] buffer)
        {
            var bufCopy = new byte[buffer.Length];
            fixed (byte* pBuf = buffer, pCopy = bufCopy)
            {
                MSVCRT.memcpy(pCopy, pBuf, buffer.Length);
            }
            return bufCopy;
        }
    }
}