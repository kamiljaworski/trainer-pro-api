namespace TrainerPro.Services.Interfaces
{
    using System.Threading.Tasks;

    public interface IViewRenderService
    {
        Task<string> RenderAsync<TModel>(string name, TModel model);
    }
}
