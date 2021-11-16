using AutoMapper;
using BookShopBE.Common.Constants;
using BookShopBE.Common.Responses;
using BookShopBE.Core.Repositories.Interfaces;
using BookShopBE.Core.Services.Interfaces;
using BookShopBE.Data.Dtos.Feedbacks;
using BookShopBE.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookShopBE.Core.Services.Implementations
{
    public class FeedbackServices : IFeedbackServices
    {
        #region Properties
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        #endregion

        #region Contructor
        public FeedbackServices(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        #endregion

        #region Public
        public async Task<Result<IEnumerable<FeedbackResponse>>> GetFeedbackOfBook(int bookId)
        {
            var book = await _unitOfWork.Books.GetById(bookId);
            if(book == null)
            {
                return Result<IEnumerable<FeedbackResponse>>.Fail(new Error
                {
                    Code = 404,
                    Message = ErrorDetails.BOOK_ID_DOES_NOT_EXIST
                });
            }

            var feedbacks = await _unitOfWork.Feedbacks.GetFeedbacksByBookId(bookId);
            if(feedbacks == null || feedbacks.Count == 0)
            {
                return Result<IEnumerable<FeedbackResponse>>.Fail(new Error
                {
                    Code = 400,
                    Message = ErrorDetails.NO_FEEDBACK_FOR_BOOK
                });
            }

            var response = _mapper.Map<IEnumerable<FeedbackResponse>>(feedbacks.AsEnumerable());
            return Result<IEnumerable<FeedbackResponse>>.Success(response);
        }

        public async Task<Result> SendFeedbackMessage(FeedbackDto dto)
        {
            var book = await _unitOfWork.Books.GetById(dto.BookId);
            if(book == null)
            {
                return new Result
                {
                    IsSuccess = false,
                    Error = new Error { Code = 404, Message = ErrorDetails.BOOK_ID_DOES_NOT_EXIST }
                };
            }

            var feedback = new Feedback
            {
                CustomerId = dto.CustomerId,
                BookId = dto.BookId,
                Message = dto.Message,
                CreatedDate = DateTime.Now
            };

            var customer = await _unitOfWork.Users.GetById(dto.CustomerId.ToString());
            feedback.CreatedBy = customer.Email;
            await _unitOfWork.Feedbacks.Add(feedback);
            await _unitOfWork.CompleteAsync();
            return new Result
            {
                IsSuccess = true,
                Error = null
            };
        }

        public async Task<Result> EditFeedbackMessage(int feedbackId, string message)
        {
            var feedback = await _unitOfWork.Feedbacks.GetById(feedbackId);
            if(feedback == null)
            {
                return new Result
                {
                    IsSuccess = false,
                    Error = new Error { Code = 404, Message = ErrorDetails.FEEDBACK_ID_DOES_NOT_EXIST }
                };
            }
            feedback.Message = message;
            await _unitOfWork.CompleteAsync();
            return new Result
            {
                IsSuccess = true,
                Error = null
            };
        }

        public async Task<Result> Delete(int feedbackId)
        {
            var feedback = await _unitOfWork.Feedbacks.GetById(feedbackId);
            if (feedback == null)
            {
                return new Result
                {
                    IsSuccess = false,
                    Error = new Error { Code = 404, Message = ErrorDetails.FEEDBACK_ID_DOES_NOT_EXIST }
                };
            }

            await _unitOfWork.Feedbacks.Delete(feedbackId);
            await _unitOfWork.CompleteAsync();

            return new Result
            {
                IsSuccess = true,
                Error = null
            };
        }

        public async Task<Result> RateStar(RateStarDto dto)
        {
            var customer = await _unitOfWork.Users.GetById(dto.CustomerId);
            var feedback = await _unitOfWork.Feedbacks.GetFeedbackToRateStar(dto.CustomerId, dto.BookId);
            if(feedback == null)
            {
                var _feedback = new Feedback
                {
                    CustomerId = dto.CustomerId,
                    BookId = dto.BookId,
                    StarRate = dto.StarRate,
                    CreatedDate = DateTime.Now
                };
                _feedback.CreatedBy = customer.Email;
                await _unitOfWork.Feedbacks.Add(_feedback);
                await _unitOfWork.CompleteAsync();
                return new Result { IsSuccess = true, Error = null };
            }
            feedback.StarRate = dto.StarRate;
            await _unitOfWork.CompleteAsync();
            return new Result { IsSuccess = true, Error = null };
        }

        #endregion Public
    }
}
