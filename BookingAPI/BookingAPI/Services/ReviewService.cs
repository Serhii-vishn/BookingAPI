namespace BookingAPI.Services
{
    public class ReviewService : IReviewService
    {
        private readonly IReviewRepository _reviewRepository;
        private readonly IBookingRepository _bookingRepository;
        private readonly IMapper _mapper;

        public ReviewService(IReviewRepository reviewRepository, IBookingRepository bookingRepository, IMapper mapper)
        {
            _reviewRepository = reviewRepository;
            _bookingRepository = bookingRepository;
            _mapper = mapper;
        }

        public async Task<ReviewDTO> GetAsync(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException("Invalid review id");
            }

            var data = await _reviewRepository.GetAsync(id);

            if (data is null)
            {
                throw new NotFoundException($"Review with id = {id} does not exist");
            }

            return _mapper.Map<ReviewDTO>(data);
        }

        public async Task<int> AddAsync(AddBookingReviewRequest reviewRequest, int accommodationId)
        {
            reviewRequest.AccommodationId = accommodationId;

            ValidateReview(reviewRequest);

            var booking = await _bookingRepository.GetAsync(reviewRequest.ClientId, accommodationId);
            if (booking is null)
            {
                throw new NotFoundException($"The client = {reviewRequest.ClientId} cannot give feedback for accomodation = {accommodationId}");
            }

            return await _reviewRepository.AddAsync(_mapper.Map<ReviewEntity>(reviewRequest));
        }

        public async Task<int> DeleteAsync(int accommodationId, int reviewId)
        {
            var reviewData = await GetAsync(reviewId);

            if(reviewData.AccommodationId != accommodationId)
            {
                throw new ArgumentException($"Invalid review id = {reviewId}");
            }

            return await _reviewRepository.DeleteAsync(reviewId);
        }

        private void ValidateReview(AddBookingReviewRequest review)
        {
            if (review is null)
            {
                throw new ArgumentNullException(nameof(review), "Review is empty");
            }

            if (!string.IsNullOrEmpty(review.Comment) && review.Comment.Length > 110)
            {
                throw new ArgumentException("Comment should be maximum 110 characters long", nameof(review.Comment));
            }

            if (review.Rating <= 0 || review.Rating > 10)
            {
                throw new ArgumentException("The rating must be greater than 0 and less than 10");
            }
        }
    }
}
