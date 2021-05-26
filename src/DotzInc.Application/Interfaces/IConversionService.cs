namespace DotzInc.Application.Interfaces
{
    public interface IConversionService
    {
        double ConvertDzInReal(int dz);
        double ConvertRealInDz(double real);
    }
}