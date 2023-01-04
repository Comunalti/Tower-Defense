using System;

namespace Core
{
    [Serializable]
    public class DoubleBufferArray<T>
    {
        public T[] bufferA;
        public T[] bufferB;

        public bool currentBufferA = true;

        public DoubleBufferArray(int size)
        {
            bufferA = new T[size];
            bufferB = new T[size];
        }

        public T[] GetCurrentBuffer()
        {
            return currentBufferA ? bufferA : bufferB;
        }
        
        public T[] GetLastFrameBuffer()
        {
            return currentBufferA ? bufferB : bufferA;
        }

        public void UpdateFrame()
        {
            currentBufferA = !currentBufferA;
            var buffer = GetCurrentBuffer();
            Array.Clear(buffer,0,buffer.Length);
        }
    }
}