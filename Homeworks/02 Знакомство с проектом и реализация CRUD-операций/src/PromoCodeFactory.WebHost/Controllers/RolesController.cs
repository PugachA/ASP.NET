using Microsoft.AspNetCore.Mvc;
using PromoCodeFactory.Core.Abstractions.Repositories;
using PromoCodeFactory.Core.Domain.Administration;
using PromoCodeFactory.WebHost.Mapping;
using PromoCodeFactory.WebHost.Models;

namespace PromoCodeFactory.WebHost.Controllers;

/// <summary>
/// Роли сотрудников
/// </summary>
[ApiController]
[Route("api/v1/[controller]")]
public class RolesController(IRepository<Role> rolesRepository) : ControllerBase
{
    /// <summary>
    /// Получить все доступные роли сотрудников
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public async Task<ActionResult<IEnumerable<RoleItemResponse>>> GetRolesAsync(CancellationToken ct)
    {
        var roles = await rolesRepository.GetAllAsync(ct);

        var rolesModels = roles.Select(Mapper.ToRoleItemResponse).ToList();

        return Ok(rolesModels);
    }
}