﻿namespace PowerAdmin.Admin.Controllers;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PowerAdmin.Admin.Services.Interfaces;
using PowerAdmin.Admin.Usecases.User;

[Route("api/[controller]")]
[ApiController]
public class UsersController : ControllerBase {
  private readonly IIdentityService identityService;

  public UsersController(IIdentityService identityService) {
    this.identityService = identityService;
  }

  [HttpGet]
  public async Task<ActionResult<PagedList<GetUsersCase.Response>>>
  GetUsers(string? search, int pageIndex = 1, int pageSize = 10) {
    return await identityService.GetUsers(search, pageIndex, pageSize);
  }

  [HttpGet("{id}")]
  public async Task<ActionResult<GetUserCase.Response>> GetUser(string id) {
    return await identityService.GetUser(id);
  }

  [HttpPost]
  public async Task<ActionResult<CreateUserCase.Response>>
  Create([FromBody] CreateUserCase.Request request) {
    return await identityService.CreateUser(request);
  }
}
