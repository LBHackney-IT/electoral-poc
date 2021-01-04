using ElectoralPOC.V1.Boundary.Response;

namespace ElectoralPOC.V1.UseCase.Interfaces
{
    public interface IGetByIdUseCase
    {
        ResponseObject Execute(int id);
    }
}
