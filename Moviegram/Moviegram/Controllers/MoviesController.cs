using Microsoft.AspNetCore.Mvc;
using Moviegram.Models.ViewModels;
using Moviegram.Repositories;

namespace Moviegram.Controllers
{
    public class MoviesController : Controller
    {
        private readonly IMoviePostRepository moviePostRepository;
        private readonly IMoviePostLikeRepository moviePostLikeRepository;

        public MoviesController(IMoviePostRepository moviePostRepository,
            IMoviePostLikeRepository moviePostLikeRepository)
        {
            this.moviePostRepository = moviePostRepository;
            this.moviePostLikeRepository = moviePostLikeRepository;
        }


        [HttpGet]
        public async Task<IActionResult> Index(string urlHandle)
        {
            var moviePost = await moviePostRepository.GetByUrlHandleAsync(urlHandle);
            var movieDetailsViewModel = new MovieDetailsViewModel();



            if ( moviePost != null)
            {
                
                var totalLikes = await moviePostLikeRepository.GetTotalLikes(moviePost.Id);

                movieDetailsViewModel = new MovieDetailsViewModel
                {
                    Id = moviePost.Id,
                    Content = moviePost.Content,
                    PageTitle = moviePost.PageTitle,
                    Author = moviePost.Author,
                    FeaturedImageUrl = moviePost.FeaturedImageUrl,
                    Heading = moviePost.Heading,
                    PublishedDate = moviePost.PublishedDate,
                    ShortDescription = moviePost.ShortDescription,
                    UrlHandle = moviePost.UrlHandle,
                    Visible = moviePost.Visible,
                    Tags = moviePost.Tags,
                    TotalLikes = totalLikes,
                };

            }
            return View(movieDetailsViewModel);
        }
    }
}
