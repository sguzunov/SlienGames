using SlienGames.Data.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SlienGames.Data.Models;
using SlienGames.Data.Contracts;

namespace SlienGames.Data.Services
{
    public class ReviewsService : IReviewsService
    {

        private readonly IRepository<Review> reviewsRepository;
        private readonly ISlienGamesData uow;

        public ReviewsService(IRepository<Review> reviewsRepository, ISlienGamesData unitOfWork)
        {

            if (reviewsRepository == null)
            {
                throw new ArgumentNullException();
            }

            if (unitOfWork == null)
            {
                throw new ArgumentNullException();
            }

            this.reviewsRepository = reviewsRepository;
            this.uow = unitOfWork;
        }
        public IEnumerable<Review> GetAll()
        {
            return this.reviewsRepository.GetAll();
        }

        public Review GetUserById(object id)
        {
            return this.reviewsRepository.GetById(id);
        }
    }
}
