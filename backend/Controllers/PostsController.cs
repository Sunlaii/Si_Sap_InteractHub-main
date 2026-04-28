using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class PostsController : ControllerBase
{
    private readonly IPostsService _postsService;

    public PostsController(IPostsService postsService)
    {
        _postsService = postsService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result = await _postsService.GetAllAsync();
        return ToActionResult(result);
    }

    [Authorize]
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreatePostRequestDto request)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        var result = await _postsService.CreateAsync(userId, request);
        return ToActionResult(result);
    }

    [Authorize]
    [HttpPost("{postId:int}/like")]
    public async Task<IActionResult> Like(int postId)
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        var result = await _postsService.LikeAsync(userId, postId);
        return ToActionResult(result);
    }

    [Authorize]
    [HttpDelete("{postId:int}/like")]
    public async Task<IActionResult> Unlike(int postId)
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        var result = await _postsService.UnlikeAsync(userId, postId);
        return ToActionResult(result);
    }

    [Authorize]
    [HttpPost("{postId:int}/comments")]
    public async Task<IActionResult> AddComment(int postId, [FromBody] AddCommentRequestDto request)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        var result = await _postsService.AddCommentAsync(userId, postId, request);
        return ToActionResult(result);
    }

    private IActionResult ToActionResult(ServiceResponse result)
    {
        if (result.StatusCode == 204)
        {
            return NoContent();
        }

        if (!string.IsNullOrWhiteSpace(result.Error))
        {
            return StatusCode(result.StatusCode, new { message = result.Error });
        }

        return StatusCode(result.StatusCode, result.Data);
    }
}
