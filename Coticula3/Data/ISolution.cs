namespace Coticula.Data
{
    public interface ISolution
    {
        int TaskId { get; }

        string Solution { get; }

        Language Language { get;  }
    }
}