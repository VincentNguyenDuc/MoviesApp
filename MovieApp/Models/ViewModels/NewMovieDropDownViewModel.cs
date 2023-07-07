using MovieApp.Models.FeatureModels;

namespace MovieApp.Models.ViewModels;

public class NewMovieDropDownViewModel
{
    public NewMovieDropDownViewModel()
    {
        Producers = new List<Producer>();
        Cinemas = new List<Cinema>();
        Actors = new List<Actor>();
    }

    public List<Producer> Producers { get; set; }
    public List<Cinema> Cinemas { get; set; }
    public List<Actor> Actors { get; set; }
}
