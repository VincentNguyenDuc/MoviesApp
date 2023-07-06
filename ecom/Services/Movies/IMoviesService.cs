using ecom.Models;
using ecom.Models.ViewModels;
using ecom.Services.Base;

namespace ecom.Services.Movies;

public interface IMoviesService:IEntityBaseService<Movie> {
    Task<Movie> GetMovieByIdAsync(int id);
    Task<NewMovieDropDownViewModel> GetNewMovieDropdownsValues();
    Task AddNewMovieAsync(NewMovieViewModel data);
    Task UpdateMovieAsync(NewMovieViewModel data);
}