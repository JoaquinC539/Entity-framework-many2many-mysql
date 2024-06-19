using Microsoft.AspNetCore.Mvc;

namespace Interfaces.IApiController;

public interface IApiController<TModel,TDto>
{
    public abstract ActionResult<IEnumerable<TModel>> Index();

    public ActionResult<TModel> GetById (int id);

    public ActionResult<TModel> Create (TDto dto);

    public ActionResult<TModel> Update (TDto dto,int id);

    public IActionResult Delete (int id);

    
}