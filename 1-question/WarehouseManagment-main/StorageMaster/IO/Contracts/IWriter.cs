namespace StorageMaster.IO.Contracts
{
    public interface IWriter
    {
        /// <summary>
        /// In the real world we would e.g use this to log to a file instead of writing to the console.
        /// </summary>
        void WriteLine(object obj);
    }
}
