namespace PartStatsIHSTest.BLL.Interfacies
{
    public interface IFileReaderFactory
    {
        IFileReader Create(string context);
    }
}
