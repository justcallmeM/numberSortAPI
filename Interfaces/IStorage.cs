namespace numsortAPI.Interfaces
{
    public interface IStorage
    {
        void SaveMyArray(double[] array);
        double[] LoadStoredArrayById(int id);
    }
}
