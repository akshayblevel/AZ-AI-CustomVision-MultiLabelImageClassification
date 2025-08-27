using AZ_AI_CustomVision_MultiLabelImageClassification.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AZ_AI_CustomVision_MultiLabelImageClassification.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClassifyController(IClassificationService classificationService) : ControllerBase
    {
        [HttpPost("ClassifyImage")]
        public async Task<IActionResult> ClassifyImage([FromBody] string imageUrl)
        {
            var result = await classificationService.ClassifyImageAsync(imageUrl) ?? "";
            return Content(result, "application/json");
        }
    }
}
