using MovieApp.Models.FeatureModels;
using MovieApp.Models.ViewModels;
using MovieApp.Services.Base;

namespace MovieApp.Services.Movies;

public interface IMoviesService:IEntityBaseService<Movie> {
    Task<Movie> GetMovieByIdAsync(int id);
    Task<NewMovieDropDownViewModel> GetNewMovieDropdownsValues();
    Task AddNewMovieAsync(NewMovieViewModel data);
    Task UpdateMovieAsync(NewMovieViewModel data);
}