using Interfaces.IApiService;
using Microsoft.AspNetCore.Mvc;

namespace Abstracts.BaseApiController;

[ApiController]
[Route("api/[controller]")]
public abstract class BaseApiController<TService,TModel,TDto> : ControllerBase where TService:IApiService<TModel,TDto>
{
    protected TService Service;
    
    public BaseApiController(TService service)
    {
        Service = service;
    }
    [HttpGet]
    public virtual ActionResult<IEnumerable<TModel>> Index()
    {
        Dictionary<string,object> parameters=new Dictionary<string,object>();
        List<TModel> entities=Service.Index(parameters).ToList();
        return Ok(entities);
    }

    [HttpGet("{id}")]
    public virtual ActionResult<TModel> GetById([FromRoute] int id)
    {
        var entity = Service.GetById(id);
        if (entity == null)
        {
            return NotFound();
        }
        return Ok(entity);
    }
    [HttpPost]
    public virtual ActionResult<TModel> Create([FromBody] TDto dto)
    {
        var entity = Service.Post(dto);
        return Ok(entity);
    }

    [HttpPut("{id}")]
    public virtual ActionResult<TModel> Edit([FromBody] TDto dto, [FromRoute] int id)
    {
        var entity = Service.Edit(dto, id);
        if (entity == null)
        {
            return NotFound();
        }
        return Ok(entity);
    }

    [HttpDelete("{id}")]
    public virtual IActionResult Delete([FromRoute] int id)
    {
        Service.Delete(id);
        return NoContent();
    }




}