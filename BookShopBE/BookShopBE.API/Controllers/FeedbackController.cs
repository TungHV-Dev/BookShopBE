using BookShopBE.Common.Responses;
using BookShopBE.Core.Services.Interfaces;
using BookShopBE.Data.Dtos.Feedbacks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace BookShopBE.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ApiVersion("1.0")]
    [Authorize]
    public class FeedbackController : ControllerBase
    {
        #region Properties
        private readonly IFeedbackServices _feedbackServices;
        #endregion Properties

        #region Contructor
        public FeedbackController(IFeedbackServices feedbackServices)
        {
            _feedbackServices = feedbackServices;
        }
        #endregion Contructor

        #region Public
        [HttpGet]
        [Route("Get-Feedback-Of-Book")]
        public async Task<ActionResult<Result<IEnumerable<FeedbackResponse>>>> GetFeedbacksOfBook(int bookId)
        {
            var response = await _feedbackServices.GetFeedbackOfBook(bookId);
            if (response.Error != null)
            {
                if (response.Error.Code == 400)
                {
                    return BadRequest(response);
                }
                return NotFound(response);
            }
            return Ok(response);
        }

        [HttpPost]
        [Route("Send-Feedback-Message")]
        public async Task<ActionResult<Result<Result>>> SendFeedbackMessage([FromForm] FeedbackRequest request)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var dto = new FeedbackDto { CustomerId = userId, BookId = request.BookId, Message = request.Message };

            var response = await _feedbackServices.SendFeedbackMessage(dto);
            if(!response.IsSuccess)
            {
                return NotFound(response);
            }

            return Ok(response);
        }

        [HttpPut]
        [Route("Edit-Feedback-Message")]
        public async Task<ActionResult<Result<Result>>> EditFeedbackMessage(int feedbackId, string message)
        {
            var response = await _feedbackServices.EditFeedbackMessage(feedbackId, message);
            if (!response.IsSuccess)
            {
                return NotFound(response);
            }
            return Ok(response);
        }

        [HttpPost]
        [Route("Rate-Star")]
        public async Task<ActionResult<Result<Result>>> RateStar([FromForm] RateStarRequest request)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var dto = new RateStarDto { CustomerId = userId, BookId = request.BookId, StarRate = request.StarRate };

            var response = await _feedbackServices.RateStar(dto);
            return Ok(response);
        }

        [HttpDelete]
        [Route("Delete-Feedback")]
        public async Task<ActionResult<Result<Result>>> DeleteFeedback(int feedbackId)
        {
            var response = await _feedbackServices.Delete(feedbackId);
            if(response.Error != null)
            {
                return NotFound(response);
            }
            return Ok(response);
        }

        #endregion Public
    }
}
